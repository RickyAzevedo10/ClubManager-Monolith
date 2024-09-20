using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IInstitutionAppService
    {
        Task<Institution?> Get(long id);
        Task<List<Institution>?> GetAll();
        Task<Institution?> Create(CreateInstitutionDTO institutionBody);
        Task<Institution?> Update(UpdateInstitutionDTO institutionToUpdate);
        Task<Institution?> Delete(long id);
    }
}
