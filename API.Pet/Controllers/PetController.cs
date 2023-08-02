using API.PET.Dominio.Entidades;
using API.PET.Dominio.Interfaces.PET;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace API.PET.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {

        private readonly IDistributedCache _distributedCache;
        private readonly IServicoPet _servicoPet;
        public PetController(IServicoPet servicoPet, IDistributedCache distributedCache)
        {
            _servicoPet = servicoPet;
            _distributedCache = distributedCache;
        }



        [HttpPost]
        [Route("/Pet")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GravarPetAsync([FromBody] Pet petRequisicaoDto)
        {

            if (petRequisicaoDto != null)
            {
                var retornoDto = await _servicoPet.GravarPetAsync(petRequisicaoDto);
                return null;
            }
            else
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                detalhesDoProblema.Type = "BadRequest";
                detalhesDoProblema.Title = "Registro não pode ser nulo";
                detalhesDoProblema.Detail = $"Dados não podem ser vazio ou nulo. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return BadRequest(detalhesDoProblema);
            }
        }



        [HttpGet]
        [Route("/Pet")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RetornaPetAsync()
        {

            var cacheKey = "petList";
            string listaPetSerializada;
       
            var petListRedis = await _distributedCache.GetAsync(cacheKey);
            if (petListRedis != null)
            {
                listaPetSerializada = Encoding.UTF8.GetString(petListRedis);
                var orderList = JsonConvert.DeserializeObject<List<Pet>>(listaPetSerializada);
                return Ok(orderList);
            }
            else
            {
                var listaPet = await _servicoPet.RetornaPetAsync();
                listaPetSerializada = JsonConvert.SerializeObject(listaPet);
                petListRedis = Encoding.UTF8.GetBytes(listaPetSerializada);
                var options = new DistributedCacheEntryOptions()
                      .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10));
                      //.SetSlidingExpiration(TimeSpan.FromMinutes(20));
                await _distributedCache.SetAsync(cacheKey, petListRedis, options);
                return Ok(listaPet);
            }
         
        }

    }
}
