using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class TrainingSessionRepository : BaseRepository<TrainingSession>, ITrainingSessionRepository
    {
        public TrainingSessionRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<TrainingSession>> GetTrainingSessionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetEntity()
                .Where(ts => ts.Date >= startDate && ts.Date <= endDate)
                .ToListAsync();
        }
    }
}
