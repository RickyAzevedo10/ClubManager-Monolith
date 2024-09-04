using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IPlayerPerformanceHistoryRepository : IBaseRepository<PlayerPerformanceHistory>
    {
        Task<PlayerPerformanceHistory?> GetByIdAsync(long id);
        Task<List<PlayerPerformanceHistory>?> GetAllPlayerPerformanceHistoryForSeasonAsync(long playerId, string season);
    }
}