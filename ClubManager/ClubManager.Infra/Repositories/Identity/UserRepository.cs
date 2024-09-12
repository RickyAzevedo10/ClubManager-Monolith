using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Repositories.Identity
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User?> GetByIdAsync(long userId)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await GetEntity().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>?> GetAllUsersFromInstitution(long idInstitution)
        {
            return await GetEntity().Where(x => x.InstitutionId == idInstitution).ToListAsync();
        }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await GetEntity()
                .FirstOrDefaultAsync(user => user.RefreshToken == refreshToken && user.RefreshTokenExpire > DateTime.UtcNow);
        }

        public async Task<User?> GetByPasswordResetTokenAsync(string passwordResetToken)
        {
            return await GetEntity()
                .FirstOrDefaultAsync(user => user.PasswordResetToken == passwordResetToken);
        }

    }
}
