using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class MatchStatisticRepository : BaseRepository<MatchStatistic>, IMatchStatisticRepository
    {
        public MatchStatisticRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<MatchStatistic>?> GetMatchStatisticsFromMatchID(long matchId)
        {
            return await GetEntity().Where(x => x.MatchId == matchId)
                .Include(x => x.Player)
                .ToListAsync();
        }

        public async Task<List<MatchStatistic>?> GetPlayerMatchStatistics(long playerId)
        {
            return await GetEntity().Where(x => x.PlayerId == playerId)
                .Include(x => x.Player)
                .ToListAsync();
        }

        public async Task<List<MatchStatistic>?> GetPlayerMatchStatisticsFromMatchId(long playerId, long matchId)
        {
            return await GetEntity().Where(x => x.PlayerId == playerId && x.MatchId == matchId)
                .Include(x => x.Player)
                .Include(x => x.Match)
                .ToListAsync();
        }
    }
}
