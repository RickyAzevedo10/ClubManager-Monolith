using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(DataContext context) : base(context)
        {
        }

        public async Task<Team?> GetByIdAsync(long id)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Team>?> GetAllPlayerFromTeamAsync(long teamId)
        {
            return await GetEntity().Where(x => x.Id == teamId)
                .Include(x => x.TeamPlayers)
                .ThenInclude(x => x.Player)
                .ToListAsync();
        }

    }
}
