using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IMaintenanceAppService
    {
        Task<MaintenanceRequest?> GetMaintenanceRequest(long maintenanceRequestId);
        Task<MaintenanceRequest?> DeleteMaintenanceRequest(long id);
        Task<MaintenanceRequest?> CreateMaintenanceRequest(CreateMaintenanceRequestDTO maintenanceRequestBody);
        Task<MaintenanceRequest?> UpdateMaintenanceRequest(UpdateMaintenanceRequestDTO maintenanceRequestToUpdate);
        Task<MaintenanceHistory?> CreateMaintenanceHistory(long maintenanceRequestId);
        Task<List<MaintenanceHistory>?> GetMaintenanceHistory(DateTime startDate, DateTime endDate);
    }
}
