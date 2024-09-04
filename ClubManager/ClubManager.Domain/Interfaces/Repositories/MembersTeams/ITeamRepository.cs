using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface ITeamRepository : IBaseRepository<Team>
    {
        Task<Team?> GetByIdAsync(long id);
        Task<List<Team>?> GetAllPlayerFromTeamAsync(long teamId);
    }
}