using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IPlayerContractRepository : IBaseRepository<PlayerContract>
    {
        Task<PlayerContract?> GetByIdAsync(long clubMemberId);
        Task<List<PlayerContract>?> GetAllPlayerContractAsync(long playerId);
    }
}