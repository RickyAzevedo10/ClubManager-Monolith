using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IFacilityAppService
    {
        Task<List<Facility>?> GetAllFacility();
        Task<Facility?> GetFacility(long facilityId);
        Task<Facility?> DeleteFacility(long id);
        Task<Facility?> CreateFacility(CreateFacilityDTO facilityBody);
        Task<Facility?> UpdateFacility(UpdateFacilityDTO facilityToUpdate);
        Task<FacilityReservation?> GetFacilityReservation(long facilityReservationId);
        Task<FacilityReservation?> DeleteFacilityReservation(long id);
        Task<FacilityReservation?> CreateFacilityReservation(CreateFacilityReservationDTO facilityReservationBody);
        Task<FacilityReservation?> UpdateFacilityReservation(UpdateFacilityReservationDTO facilityReservationToUpdate);
    }
}
