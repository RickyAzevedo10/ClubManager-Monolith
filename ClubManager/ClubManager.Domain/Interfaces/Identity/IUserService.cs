using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IUserService
    {
        Task<User?> Get(long id);
        Task<List<User>?> GetAllUsersFromInstitution(long idInstitution);
        Task<User?> Create(CreateUserDTO createUser);
        Task<User?> Update(CreateUserDTO userToUpdate, User user);
        Task<User?> Delete(long id);
        void UpdateRefreshToken(User user, string refreshToken);
        Task<UserPermissions?> CreateUserPermissions(CreateUserPermissionsDTO createUserPermissions);
        Task<UserPermissions?> DeleteUserPermissions(long id);
        Task<UserPermissions?> UpdateUserPermissions(UpdateUserPermissionsDTO updateUserPermissions, UserPermissions userPermissions);
        void UpdatePasswordResetToken(User user, string passwordResetToken);
        Task<User?> UpdatePassword(User user, ResetPassword request);
    }
}