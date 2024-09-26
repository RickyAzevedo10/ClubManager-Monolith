using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<IEnumerable<Player>> SearchPlayersAsync(string? firstName, string? lastName, string? position);
        Task<Player?> GetByIdAsync(long id);
    }
}