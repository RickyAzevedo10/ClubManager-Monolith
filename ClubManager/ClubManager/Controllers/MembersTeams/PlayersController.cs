using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;
        private readonly ModelErrorsContext _modelErrorsContext;
        private readonly IPlayerAppService _playerAppService;

        public PlayersController(NotificationContext notificationContext, ModelErrorsContext modelErrorsContext, IPlayerAppService playerAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _playerAppService = playerAppService;
        }

        #region Player
        /// <summary>
        /// create player
        /// </summary>
        /// <param name="playerBody"></param>
        /// <returns></returns>
        [HttpPost("Player")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PostPlayer(CreatePlayerDTO playerBody)
        {
            Player? response = await _playerAppService.CreatePlayer(playerBody);
            return DomainResult<Player?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete player
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Player")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> DeletePlayer(long id)
        {
            Player? response = await _playerAppService.DeletePlayer(id);
            return DomainResult<Player?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get player with search
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpGet("PlayerSearch")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> SearchPlayers([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? position)
        {
            var players = await _playerAppService.SearchPlayersAsync(firstName, lastName, position);
            return Ok(players);
        }

        /// <summary>
        /// get player
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("Players")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetPlayer(long playerId) //TODO: adicionar a informacao do responsavel do player
        {
            Player? response = await _playerAppService.GetPlayer(playerId);
            return DomainResult<Player?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update player
        /// </summary>
        /// <param name="playerToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Players")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PutPlayers(UpdatePlayerDTO playerToUpdate)
        {
            Player? response = await _playerAppService.UpdatePlayer(playerToUpdate);
            return DomainResult<Player?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion

        #region PlayerTransfer
        /// <summary>
        /// create PlayerTransfer
        /// </summary>
        /// <param name="playerTransferBody"></param>
        /// <returns></returns>
        [HttpPost("PlayerTransfer")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PostPlayerTransfer(CreatePlayerTransferDTO playerTransferBody)
        {
            PlayerTransfer? response = await _playerAppService.CreatePlayerTransfer(playerTransferBody);
            return DomainResult<PlayerTransfer?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete PlayerTransfer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("PlayerTransfer")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> DeletePlayerTransfer(long id)
        {
            PlayerTransfer? response = await _playerAppService.DeletePlayerTransfer(id);
            return DomainResult<PlayerTransfer?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all PlayerTransfer
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("PlayerTransfer")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetPlayerTransfer(long playerId)
        {
            List<PlayerTransfer>? response = await _playerAppService.GetPlayerTransfer(playerId);
            return DomainResult<List<PlayerTransfer>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update PlayerTransfer
        /// </summary>
        /// <param name="playerTransferToUpdate"></param>
        /// <returns></returns>
        [HttpPut("PlayerTransfer")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PutPlayerTransfer(UpdatePlayerTransferDTO playerTransferToUpdate)
        {
            PlayerTransfer? response = await _playerAppService.UpdatePlayerTransfer(playerTransferToUpdate);
            return DomainResult<PlayerTransfer?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion

        #region PlayerContract
        /// <summary>
        /// create PlayerContract
        /// </summary>
        /// <param name="playerContractBody"></param>
        /// <returns></returns>
        [HttpPost("PlayerContract")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PostPlayerContract(CreatePlayerContractDTO playerContractBody)
        {
            PlayerContract? response = await _playerAppService.CreatePlayerContract(playerContractBody);
            return DomainResult<PlayerContract?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete PlayerContract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("PlayerContract")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> DeletePlayerContract(long id)
        {
            PlayerContract? response = await _playerAppService.DeletePlayerContract(id);
            return DomainResult<PlayerContract?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all PlayerContract
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("PlayerContract")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetPlayerContract(long playerId)
        {
            List<PlayerContract>? response = await _playerAppService.GetPlayerContract(playerId);
            return DomainResult<List<PlayerContract>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update PlayerContract
        /// </summary>
        /// <param name="playerContractToUpdate"></param>
        /// <returns></returns>
        [HttpPut("PlayerContract")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PutPlayerContract(UpdatePlayerContractDTO playerContractToUpdate)
        {
            PlayerContract? response = await _playerAppService.UpdatePlayerContract(playerContractToUpdate);
            return DomainResult<PlayerContract?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion

        #region PlayerPerformanceHistory
        /// <summary>
        /// create PlayerPerformanceHistory
        /// </summary>
        /// <param name="playerPerformanceHistory"></param>
        /// <returns></returns>
        [HttpPost("PlayerPerformanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PostPlayerPerformanceHistory(CreatePlayerPerformanceHistoryDTO playerPerformanceHistory)
        {
            PlayerPerformanceHistory? response = await _playerAppService.CreatePlayerPerformanceHistory(playerPerformanceHistory);
            return DomainResult<PlayerPerformanceHistory?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete PlayerPerformanceHistory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("PlayerPerformanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> DeletePlayerPerformanceHistory(long id)
        {
            PlayerPerformanceHistory? response = await _playerAppService.DeletePlayerPerformanceHistory(id);
            return DomainResult<PlayerPerformanceHistory?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get PlayerPerformanceHistory
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        [HttpGet("PlayerPerformanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetPlayerPerformanceHistory(long playerId, string season)
        {
            PlayerPerformanceHistoryResponseDTO? response = await _playerAppService.GetPlayerPerformanceHistory(playerId, season);
            return DomainResult<PlayerPerformanceHistoryResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update PlayerPerformanceHistory
        /// </summary>
        /// <param name="playerPerformanceHistoryToUpdate"></param>
        /// <returns></returns>
        [HttpPut("PlayerPerformanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PutPlayerPerformanceHistory(UpdatePlayerPerformanceHistoryDTO playerPerformanceHistoryToUpdate)
        {
            PlayerPerformanceHistory? response = await _playerAppService.UpdatePlayerPerformanceHistory(playerPerformanceHistoryToUpdate);
            return DomainResult<PlayerPerformanceHistory?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion
    }
}
