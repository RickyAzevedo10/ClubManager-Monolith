using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(DataContext context) : base(context)
        {
        }

        public async Task<Match?> GetByIdAsync(long id)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Match>?> GetMachesByTeamId(long teamId)
        {
            return await GetEntity().Where(x => x.TeamId == teamId)
                .Include(x => x.Team)
                .ToListAsync();
        }
    }
}
