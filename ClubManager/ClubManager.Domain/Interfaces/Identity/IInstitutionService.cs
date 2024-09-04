using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IInstitutionService
    {
        Task<Institution?> Get(long id);
        Task<List<Institution>?> GetAll();
        Task<Institution?> Create(Institution institutionBody);
        Task<Institution?> Update(Institution institutionToUpdate);
        Task<Institution?> Delete(long id);
    }
}