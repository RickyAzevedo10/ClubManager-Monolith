using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IInstitutionAppService
    {
        Task<Institution?> Get(long id);
        Task<List<Institution>?> GetAll();
        Task<Institution?> Create(Institution institutionBody);
        Task<Institution?> Update(Institution institutionToUpdate);
        Task<Institution?> Delete(long id);
    }
}
