using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IEntityService
    {
        Task<Entity?> CreateEntity(CreateEntityDTO entityBody);
        Task<Entity?> UpdateEntity(UpdateEntityDTO entityToUpdate, Entity entity);
        Task<Entity?> DeleteEntity(long id);
    }
}