using AutoMapper;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.Application.Mappings
{
    public class FinancialMappingProfile : Profile
    {
        public FinancialMappingProfile()
        {
            CreateMap<Entity, EntityResponseDTO>();
            CreateMap<Expense, ExpenseResponseDTO>();
            CreateMap<Revenue, RevenueResponseDTO>();
        }
    }
}
