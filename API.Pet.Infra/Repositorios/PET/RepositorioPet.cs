
using MongoDB.Driver;
using Api.Coopera.Dominios.Dominio.Interfaces;
using Api.Coopera.Dominios.Infra.Contextos;
using API.PET.Dominio.Entidades;
using API.PET.Dominio.Interfaces.PET;

namespace API.PET.Infra.Repositorios.PET
{
    public class RepositorioPet : IRepositorioPet
    {
        private readonly IContexto _contexto;

        public RepositorioPet()
        {
            _contexto = new Contexto();
        }

        public async Task GravarPetAsync(Pet petRequisicaoDto)
        {
            try
            {
                await _contexto.Pets.InsertOneAsync(petRequisicaoDto);
            }
            catch (Exception ex) { 
            }
             
        }

        public  async Task<List<Pet>> RetornaPetAsync()
        {
              var categorias = await _contexto.Pets.FindAsync(_ => true);
               return categorias.ToList();
        }

        //public async Task<List<Pet>>  RetornaPetAsync()
        //{
        //    var categorias = await _contexto.Pets.FindAsync(_ => true);
        //    return categorias.ToList();
        //}
    }
}
