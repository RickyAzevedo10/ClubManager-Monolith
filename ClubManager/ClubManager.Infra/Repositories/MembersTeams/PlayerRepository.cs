using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext context) : base(context)
        {
        }

        public async Task<Player?> GetByIdAsync(long id)
        {
            return await GetEntity().Include(x => x.PlayerResponsibles).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Player>> SearchPlayersAsync(string? firstName, string? lastName, string? position)
        {
            IQueryable<Player> query = GetEntity();

            query = query.Include(x => x.PlayerResponsibles)
                .Include(x => x.PlayerTransfers)
                .Include(x => x.PlayerContracts)
                .Include(x => x.PlayerPerformanceHistories);

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(p => p.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(p => p.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(position))
            {
                query = query.Where(p => p.Position.Contains(position));
            }

            return await query.Take(15).ToListAsync();
        }
    }
}
