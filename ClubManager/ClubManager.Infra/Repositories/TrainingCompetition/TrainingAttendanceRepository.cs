using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class TrainingAttendanceRepository : BaseRepository<TrainingAttendance>, ITrainingAttendanceRepository
    {
        public TrainingAttendanceRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<TrainingAttendance>?> GetTrainingAttendanceByPlayerId(long playerId)
        {
            return await GetEntity().Where(x => x.PlayerId == playerId)
                .ToListAsync();
        }
    }
}
