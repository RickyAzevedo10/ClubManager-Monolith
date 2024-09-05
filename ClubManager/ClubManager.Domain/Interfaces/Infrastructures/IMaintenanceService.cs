using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.Domain.Interfaces.Infrastructures
{
    public interface IMaintenanceService
    {
        Task<MaintenanceRequest?> DeleteMaintenanceRequest(long id);
        Task<MaintenanceRequest?> CreateMaintenanceRequest(CreateMaintenanceRequestDTO maintenanceRequestBody);
        Task<MaintenanceRequest?> UpdateMaintenanceRequest(UpdateMaintenanceRequestDTO maintenanceRequestToUpdate, MaintenanceRequest maintenanceRequest);
        Task<MaintenanceHistory?> CreateMaintenanceHistory(long maintenanceRequestId);
    }
}
