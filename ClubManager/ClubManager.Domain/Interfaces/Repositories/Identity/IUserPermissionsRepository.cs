using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IUserPermissionsRepository : IBaseRepository<UserPermissions>
    {
        Task<List<UserPermissions>?> GetUserPermissions(long userId);
    }
}