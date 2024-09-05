using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class MaintenanceHistoryRepository : BaseRepository<MaintenanceHistory>, IMaintenanceHistoryRepository
    {
        public MaintenanceHistoryRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceHistory>> GetMaintenanceHistoryByDateRange(DateTime startDate, DateTime endDate)
        {
            return await GetEntity().Where(mh => mh.MaintenanceDate >= startDate && mh.MaintenanceDate <= endDate).ToListAsync();
        }
    }
}
