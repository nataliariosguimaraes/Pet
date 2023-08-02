using API.PET.Dominio.Entidades;

namespace API.PET.Dominio.Interfaces.PET
{
    public interface IRepositorioPet
    {
        Task GravarPetAsync(Pet petRequisicaoDto);
        Task<List<Pet>> RetornaPetAsync();
    }
}
