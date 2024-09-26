using AutoMapper;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Application.Mappings
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<Institution, InstitutionResponseDTO>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<UserRoles, UserRoleResponseDTO>();
            CreateMap<UserPermissions, UserPermissionResponseDTO>();
        }
    }
}
