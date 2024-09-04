using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class PlayerTransferRepository : BaseRepository<PlayerTransfer>, IPlayerTransferRepository
    {
        public PlayerTransferRepository(DataContext context) : base(context)
        {
        }

        public async Task<PlayerTransfer?> GetByIdAsync(long id)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<PlayerTransfer>?> GetAllPlayerTransferAsync(long playerId)
        {
            return await GetEntity().Where(x => x.PlayerId == playerId).ToListAsync();
        }

    }
}
