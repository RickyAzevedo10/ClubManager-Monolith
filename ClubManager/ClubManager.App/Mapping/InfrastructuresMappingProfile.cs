using AutoMapper;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;

namespace ClubManager.Application.Mappings
{
    public class InfrastructuresMappingProfile : Profile
    {
        public InfrastructuresMappingProfile()
        {
            CreateMap<Facility, FacilityResponseDTO>();
            CreateMap<FacilityCategory, FacilityCategoryResponseDTO>();
            CreateMap<FacilityReservation, FacilityReservationResponseDTO>();
            CreateMap<MaintenanceRequest, MaintenanceRequestResponseDTO>();
        }
    }
}
