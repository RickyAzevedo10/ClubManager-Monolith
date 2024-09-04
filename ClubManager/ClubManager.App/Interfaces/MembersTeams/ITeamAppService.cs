using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.App.Interfaces.Identity
{
    public interface ITeamAppService
    {
        Task<List<Team>?> GetTeams();
        Task<List<Team>?> GetAllPlayersFromTeam(long teamId);
        Task<Team?> DeleteTeam(long id);
        Task<Team?> CreateTeam(CreateTeamDTO teamBody);
        Task<Team?> UpdateTeam(UpdateTeamDTO teamToUpdate);
    }
}
