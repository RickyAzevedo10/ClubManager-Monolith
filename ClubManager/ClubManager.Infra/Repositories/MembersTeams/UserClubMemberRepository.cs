using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class UserClubMemberRepository : BaseRepository<UserClubMember>, IUserClubMemberRepository
    {
        public UserClubMemberRepository(DataContext context) : base(context)
        {
        }

        public async Task<UserClubMember?> GetByUserIdAsync(long userId)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
