using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IFacilityAppService
    {
        Task<List<FacilityResponseDTO>?> GetAllFacility();
        Task<FacilityResponseDTO?> GetFacility(long facilityId);
        Task<FacilityResponseDTO?> DeleteFacility(long id);
        Task<FacilityResponseDTO?> CreateFacility(CreateFacilityDTO facilityBody);
        Task<FacilityResponseDTO?> UpdateFacility(UpdateFacilityDTO facilityToUpdate);
        Task<FacilityReservationResponseDTO?> GetFacilityReservation(long facilityReservationId);
        Task<FacilityReservationResponseDTO?> DeleteFacilityReservation(long id);
        Task<FacilityReservationResponseDTO?> CreateFacilityReservation(CreateFacilityReservationDTO facilityReservationBody);
        Task<FacilityReservationResponseDTO?> UpdateFacilityReservation(UpdateFacilityReservationDTO facilityReservationToUpdate);
    }
}
