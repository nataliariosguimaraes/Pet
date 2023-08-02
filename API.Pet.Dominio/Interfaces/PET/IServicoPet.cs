using API.PET.Dominio.Entidades;

namespace API.PET.Dominio.Interfaces.PET
{
    public interface IServicoPet
    {
        Task<bool> GravarPetAsync(Pet petRequisicaoDto);
        Task<List<Pet>> RetornaPetAsync();
    }
}
