using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IUserAppService
    {
        Task<User?> Get(long id);
        Task<List<User>?> GetAllFromInstitution(long idInstitution);
        Task<List<UserRoles>?> GetAllUserRoles();
        Task<List<UserPermissions>?> GetUserPermissions(long id);
        Task<User?> Create(CreateUserDTO userCreate);
        Task<User?> Update(CreateUserDTO userCreateToUpdate);
        Task<User?> Delete(long id);
        Task<UserLoginResponseDTO?> Login(UserLoginDTO user);
        Task<UserLoginResponseDTO?> Refresh(string refreshToken);
        Task<UserPermissions?> PutUserPermissions(UpdateUserPermissionsDTO userPermissionsCreate);
        Task<UserPermissions?> DeleteUserPermissions(long id);
        Task<User?> CreateUserAdmin(string abbreviation);
        Task<RecoverPasswordRequestResponse?> RecoverPassword(RecoverPasswordRequest request);
        Task<ResetPasswordResponse?> ResetPassword(ResetPassword request);
    }
}
