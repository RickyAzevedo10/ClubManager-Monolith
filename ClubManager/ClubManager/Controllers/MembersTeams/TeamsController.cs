using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly ITeamAppService _teamAppService;

        public TeamsController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, ITeamAppService teamAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _teamAppService = teamAppService;
        }

        /// <summary>
        /// get all teams
        /// </summary>
        /// <returns></returns>
        [HttpGet("Teams")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário,Treinador")]
        public async Task<IActionResult> GetTeams()
        {
            List<Team>? response = await _teamAppService.GetTeams();
            return DomainResult<List<Team>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all players from a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet("Team")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário,Treinador")]
        public async Task<IActionResult> GetAllPlayersFromTeam(long teamId)
        {
            List<Team>? response = await _teamAppService.GetAllPlayersFromTeam(teamId);
            return DomainResult<List<Team>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update team
        /// </summary>
        /// <param name="teamToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Team")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário,Treinador")]
        public async Task<IActionResult> PutPlayerTransfer(UpdateTeamDTO teamToUpdate)
        {
            Team? response = await _teamAppService.UpdateTeam(teamToUpdate);
            return DomainResult<Team?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Team")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário,Treinador")]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            Team? response = await _teamAppService.DeleteTeam(id);
            return DomainResult<Team?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// create team
        /// </summary>
        /// <param name="teamBody"></param>
        /// <returns></returns>
        [HttpPost("Team")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário,Treinador")]
        public async Task<IActionResult> PostTeam(CreateTeamDTO teamBody)
        {
            Team? response = await _teamAppService.CreateTeam(teamBody);
            return DomainResult<Team?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
    }
}
