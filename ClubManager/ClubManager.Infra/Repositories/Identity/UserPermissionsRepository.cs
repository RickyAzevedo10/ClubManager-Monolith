using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class UserPermissionsRepository : BaseRepository<UserPermissions>, IUserPermissionsRepository
    {
        public UserPermissionsRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<UserPermissions>?> GetUserPermissions(long userId)
        {
            return await GetEntity().Where(x => x.Users.Id == userId).ToListAsync();
        }

    }
}
