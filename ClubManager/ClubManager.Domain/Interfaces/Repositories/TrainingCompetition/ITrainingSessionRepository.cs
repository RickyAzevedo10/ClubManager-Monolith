using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface ITrainingSessionRepository : IBaseRepository<TrainingSession>
    {
        Task<List<TrainingSession>> GetTrainingSessionsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}