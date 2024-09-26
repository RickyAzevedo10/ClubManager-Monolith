using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class ClubMemberRepository : BaseRepository<ClubMember>, IClubMemberRepository
    {
        public ClubMemberRepository(DataContext context) : base(context)
        {
        }

        public async Task<ClubMember?> GetByIdAsync(long id)
        {
            return await GetEntity().Include(x => x.UserClubMember).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ClubMember?> GetByEmailAsync(string email)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<ClubMember>> SearchClubMembersAsync(string? firstName, string? lastName)
        {
            var query = GetEntity();  

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(m => EF.Functions.Like(m.FirstName, $"%{firstName}%"));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(m => EF.Functions.Like(m.LastName, $"%{lastName}%"));
            }

            return await query.ToListAsync();
        }
    }
}
