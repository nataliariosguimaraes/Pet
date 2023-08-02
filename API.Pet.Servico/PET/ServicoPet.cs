using API.PET.Dominio.Entidades;
using API.PET.Dominio.Interfaces.PET;
using API.PET.Infra.Repositorios.PET;

namespace API.PET.Servico.PET
{
    public class ServicoPet : IServicoPet
    {
        private readonly IRepositorioPet _repositorioPet;

        public ServicoPet()
        {
            _repositorioPet = new RepositorioPet();
        }


        public async Task<bool> GravarPetAsync(Pet petRequisicaoDto)
        {


            try
            {
                var ret = _repositorioPet.GravarPetAsync(petRequisicaoDto);
            }
            catch (Exception ex)
            {
            }

            return false;
        }


        public async Task<List<Pet>> RetornaPetAsync()
        {
            return await _repositorioPet.RetornaPetAsync();
        }


    }
}
