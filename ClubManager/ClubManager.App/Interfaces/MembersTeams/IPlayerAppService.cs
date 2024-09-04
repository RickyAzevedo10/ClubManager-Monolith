using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IPlayerAppService
    {
        Task<Player?> GetPlayer(long id);
        Task<List<PlayerTransfer>?> GetPlayerTransfer(long id);
        Task<List<PlayerContract>?> GetPlayerContract(long id);
        Task<PlayerTransfer?> DeletePlayerTransfer(long id);
        Task<Player?> DeletePlayer(long id);
        Task<PlayerContract?> DeletePlayerContract(long id);
        Task<PlayerPerformanceHistory?> DeletePlayerPerformanceHistory(long id);
        Task<PlayerTransfer?> CreatePlayerTransfer(CreatePlayerTransferDTO playerTransferBody);
        Task<PlayerTransfer?> UpdatePlayerTransfer(UpdatePlayerTransferDTO playerTransferToUpdate);
        Task<PlayerContract?> CreatePlayerContract(CreatePlayerContractDTO playerContractBody);
        Task<PlayerContract?> UpdatePlayerContract(UpdatePlayerContractDTO playerContractToUpdate);
        Task<PlayerPerformanceHistory?> CreatePlayerPerformanceHistory(CreatePlayerPerformanceHistoryDTO playerPerformanceHistoryBody);
        Task<PlayerPerformanceHistory?> UpdatePlayerPerformanceHistory(UpdatePlayerPerformanceHistoryDTO playerPerformanceHistoryToUpdate);
        Task<PlayerPerformanceHistoryResponseDTO?> GetPlayerPerformanceHistory(long playerId, string season);
        Task<Player?> CreatePlayer(CreatePlayerDTO playerBody);
        Task<Player?> UpdatePlayer(UpdatePlayerDTO playerToUpdate);
        Task<List<Player>?> SearchPlayersAsync(string? firstName, string? lastName, string? position);
    }
}
