using API.PET.Dominio.Entidades;
using MongoDB.Driver;

namespace Api.Coopera.Dominios.Dominio.Interfaces
{
    public interface IContexto
    {
        IMongoCollection<Pet> Pets { get; }
    }
}
