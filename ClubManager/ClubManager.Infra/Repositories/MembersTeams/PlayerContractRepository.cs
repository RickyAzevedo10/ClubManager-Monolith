using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class PlayerContractRepository : BaseRepository<PlayerContract>, IPlayerContractRepository
    {
        public PlayerContractRepository(DataContext context) : base(context)
        {
        }

        public async Task<PlayerContract?> GetByIdAsync(long userId)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<PlayerContract>?> GetAllPlayerContractAsync(long playerId)
        {
            return await GetEntity().Where(x => x.PlayerId == playerId).ToListAsync();
        }

    }
}
