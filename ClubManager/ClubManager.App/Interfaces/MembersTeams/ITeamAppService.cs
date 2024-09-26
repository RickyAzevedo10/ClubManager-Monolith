using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.App.Interfaces.Identity
{
    public interface ITeamAppService
    {
        Task<List<TeamResponseDTO>?> GetTeams();
        Task<List<TeamResponseDTO>?> GetAllPlayersFromTeam(long teamId);
        Task<TeamResponseDTO?> DeleteTeam(long id);
        Task<TeamResponseDTO?> CreateTeam(CreateTeamDTO teamBody);
        Task<TeamResponseDTO?> UpdateTeam(UpdateTeamDTO teamToUpdate);
    }
}
