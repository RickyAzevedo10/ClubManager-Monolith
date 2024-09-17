using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IRevenueService
    {
        Task<List<Revenue>?> CreateRevenue(List<RevenueDTO> revenueBody);
        Task<Revenue?> DeleteRevenue(long id);
        Task<List<Revenue>?> UpdateRevenue(List<UpdateRevenueDTO> revenueBody);
    }
}