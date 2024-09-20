using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IInstitutionService
    {
        Task<Institution?> Get(long id);
        Task<List<Institution>?> GetAll();
        Task<Institution?> Create(CreateInstitutionDTO institutionBody);
        Task<Institution?> Update(UpdateInstitutionDTO institutionToUpdate, Institution institution);
        Task<Institution?> Delete(long id);
    }
}