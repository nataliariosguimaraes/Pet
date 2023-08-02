using Api.Coopera.Dominios.Dominio.Interfaces;
using API.PET.Dominio.Entidades;
using API.PET.Utilitarios;
using MongoDB.Driver;

namespace Api.Coopera.Dominios.Infra.Contextos
{
    internal class Contexto : IContexto
    {
      

        public IMongoCollection<Pet> Pets { get; }

        public Contexto()
        {
            var cliente = new MongoClient(ConfiguracoesDaAplicacao.ObterStringDeConexaoMongoDB());
            var bancoDados = cliente.GetDatabase("Pet");
            Pets = bancoDados.GetCollection<Pet>("Pet");

        }
    }
}
