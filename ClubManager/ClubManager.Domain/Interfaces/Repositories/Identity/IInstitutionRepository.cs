using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IInstitutionRepository : IBaseRepository<Institution>
    {
        Task<Institution?> GetByIdAsync(long userId);
        Task<Institution?> GetByNameAsync(string name);
    }
}