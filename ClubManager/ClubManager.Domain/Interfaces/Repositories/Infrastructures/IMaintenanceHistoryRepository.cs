using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IMaintenanceHistoryRepository : IBaseRepository<MaintenanceHistory>
    {
        Task<List<MaintenanceHistory>> GetMaintenanceHistoryByDateRange(DateTime startDate, DateTime endDate);
    }
}