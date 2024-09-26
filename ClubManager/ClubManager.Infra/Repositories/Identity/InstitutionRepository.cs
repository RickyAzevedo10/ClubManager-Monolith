using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(DataContext context) : base(context)
        {
        }

        public async Task<Institution?> GetByIdAsync(long userId)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<Institution?> GetByNameAsync(string name)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
