using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IRevenueService
    {
        Task<Revenue?> CreateRevenue(RevenueDTO revenueBody);
        Task<Revenue?> DeleteRevenue(long id);
        Task<Revenue?> UpdateRevenue(UpdateRevenueDTO revenueBody);
    }
}