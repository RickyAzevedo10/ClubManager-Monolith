using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface ITrainingAttendanceRepository : IBaseRepository<TrainingAttendance>
    {
        Task<List<TrainingAttendance>?> GetTrainingAttendanceByPlayerId(long playerId);
    }
}