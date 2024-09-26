using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IMaintenanceAppService
    {
        Task<MaintenanceRequestResponseDTO?> GetMaintenanceRequest(long maintenanceRequestId);
        Task<MaintenanceRequestResponseDTO?> DeleteMaintenanceRequest(long id);
        Task<MaintenanceRequestResponseDTO?> CreateMaintenanceRequest(CreateMaintenanceRequestDTO maintenanceRequestBody);
        Task<MaintenanceRequestResponseDTO?> UpdateMaintenanceRequest(UpdateMaintenanceRequestDTO maintenanceRequestToUpdate);
        Task<MaintenanceHistory?> CreateMaintenanceHistory(long maintenanceRequestId);
        Task<List<MaintenanceHistory>?> GetMaintenanceHistory(DateTime startDate, DateTime endDate);
    }
}
