using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IMatchRepository : IBaseRepository<Match>
    {
        Task<Match?> GetByIdAsync(long id);
        Task<List<Match>?> GetMachesByTeamId(long teamId);
    }
}