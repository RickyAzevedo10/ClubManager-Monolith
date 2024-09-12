using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IRevenueAppService
    {
        Task<List<Revenue>?> CreateRevenue(CreateRevenueDTO revenueBody);
        Task<Revenue?> DeleteRevenue(long id);
        Task<List<Revenue>?> UpdateRevenue(UpdateEntityRevenueDTO revenueToUpdate);
        Task<List<Entity>?> GetAllRevenue();
        Task<Entity?> GetRevenue(long revenueId);
    }
}
