using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IEntityAppService
    {
        Task<Entity?> DeleteEntity(long id);
        Task<Entity?> CreateEntity(CreateEntityDTO entityBody);
        Task<Entity?> UpdateEntity(UpdateEntityDTO entityToUpdate);
        Task<Entity?> GetEntity(long entityId);
        Task<List<Entity>?> GetAllEntity();
    }
}
