using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly IMatchAppService _matchAppService;

        public MatchController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, IMatchAppService matchAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _matchAppService = matchAppService;
        }

        #region Match

        /// <summary>
        /// Create Match
        /// </summary>
        /// <param name="matchBody"></param>
        /// <returns></returns>
        [HttpPost("Match")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PostMatch(CreateMatchDTO matchBody)
        {
            Match? response = await _matchAppService.CreateMatch(matchBody);
            return DomainResult<Match?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update match
        /// </summary>
        /// <param name="teamToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Match")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PutMatch(UpdateMatchDTO matchToUpdate)
        {
            Match? response = await _matchAppService.UpdateMatch(matchToUpdate);
            return DomainResult<Match?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Delete match
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Match")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> DeleteMatch(long id)
        {
            Match? response = await _matchAppService.DeleteMatch(id);
            return DomainResult<Match?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Get Match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        [HttpGet("MatchId")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetMatch(long matchId)
        {
            Match? response = await _matchAppService.GetMatch(matchId);
            return DomainResult<Match?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Get Team matches
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet("Match")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetTeamMatches(long teamId)
        {
            List<Match>? response = await _matchAppService.GetTeamMatches(teamId);
            return DomainResult<List<Match>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion


        #region MatchStatistics
        /// <summary>
        /// create MatchStatistics
        /// </summary>
        /// <param name="matchStatisticBody"></param>
        /// <returns></returns>
        [HttpPost("MatchStatistics")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PostMatchStatistics(CreateMatchStatisticDTO matchStatisticBody)
        {
            MatchStatistic? response = await _matchAppService.CreateMatchStatistic(matchStatisticBody);
            return DomainResult<MatchStatistic?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete MatchStatistics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("MatchStatistics")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> DeleteMatchStatistic(long id)
        {
            MatchStatistic? response = await _matchAppService.DeleteMatchStatistic(id);
            return DomainResult<MatchStatistic?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update MatchStatistics
        /// </summary>
        /// <param name="matchStatisticToUpdate"></param>
        /// <returns></returns>
        [HttpPut("MatchStatistics")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PutMatchStatistic(UpdateMatchStatisticDTO matchStatisticToUpdate)
        {
            MatchStatistic? response = await _matchAppService.UpdateMatchStatistic(matchStatisticToUpdate);
            return DomainResult<MatchStatistic?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get match statistic
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        [HttpGet("MatchStatistics/MatchId")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetMatchStatisticsFromMatchID(long matchId)
        {
            List<MatchStatistic>? response = await _matchAppService.GetMatchStatisticsFromMatchID(matchId);
            return DomainResult<List<MatchStatistic>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get player statistic
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("MatchStatistics/PlayerId")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetPlayerMatchStatistics(long playerId)
        {
            List<MatchStatistic>? response = await _matchAppService.GetPlayerMatchStatistics(playerId);
            return DomainResult<List<MatchStatistic>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get player statistic from a game
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        [HttpGet("MatchStatistics")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetPlayerMatchStatisticsFromMatchId(long playerId, long matchId)
        {
            List<MatchStatistic>? response = await _matchAppService.GetPlayerMatchStatisticsFromMatchId(playerId, matchId);
            return DomainResult<List<MatchStatistic>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion


    }
}
