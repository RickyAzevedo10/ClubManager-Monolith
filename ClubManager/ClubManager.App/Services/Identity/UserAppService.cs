using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Identity
{
    public class UserAppService : IUserAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserClaimsService _userClaimsService;

        public UserAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserService userService, IAuthenticationService authenticationService, IUserClaimsService userClaimsService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userService = userService;
            _authenticationService = authenticationService;
            _userClaimsService = userClaimsService;
        }

        public async Task<User?> Get(long id)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            User? user = await _userService.Get(id);

            return user;
        }

        public async Task<List<User>?> GetAllFromInstitution(long idInstitution)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<User>? usersInstitution = await _userService.GetAllUsersFromInstitution(idInstitution);

            return usersInstitution;
        }

        public async Task<List<UserRoles>?> GetAllUserRoles()
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<UserRoles>? userRoles = await _unitOfWork.UserRolesRepository.GetAllAsync();

            return userRoles.ToList();
        }

        public async Task<List<UserPermissions>?> GetUserPermissions(long id)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<UserPermissions>? userPermissions = await _unitOfWork.UserPermissionsRepository.GetUserPermissions(id);

            return userPermissions;
        }

        public async Task<User?> Create(CreateUserDTO userCreate)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canCreate;
            if (userAuthenticated != null)
                canCreate = _authorizationService.CanCreate(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            } 

            User? user = await _unitOfWork.UserRepository.GetByEmailAsync(userCreate.Email);

            if (user != null)
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_ALREADY_EXITS, string.Empty);
                return null;
            }

            CreateUserPermissionsDTO createUserPermissionsDTO = new()
            {
                Edit = userCreate.Edit,
                Consult = userCreate.Consult,
                Delete = userCreate.Delete,
                Create = userCreate.Create,
            };
            UserPermissions? userPermissions = await _userService.CreateUserPermissions(createUserPermissionsDTO);

            user = await _userService.Create(userCreate);

            if(userPermissions != null && user != null)
                user.UserPermission = userPermissions;

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return user;
        }

        public async Task<User?> Update(CreateUserDTO userCreateToUpdate)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canEdit;

            if (userAuthenticated != null)
                canEdit = _authorizationService.CanEdit(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            User? user = await _unitOfWork.UserRepository.GetByEmailAsync(userCreateToUpdate.Email);

            if (user == null)
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            user = await _userService.Update(userCreateToUpdate, user);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return user;
        }

        public async Task<User?> Delete(long id)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canDelete;
            if (userAuthenticated != null)
                canDelete = _authorizationService.CanDelete(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            User? userDeleted = await _userService.Delete(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return userDeleted;
        }

        public async Task<UserLoginResponseDTO?> Login(UserLoginDTO user)
        {
            var existentUser = await _unitOfWork.UserRepository.GetByEmailAsync(user.Email);

            if (existentUser == null)
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!existentUser.ValidatePassword(user.Password))
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.INVALID_USER_CREDENTIALS, string.Empty);
                return null;
            }

            var refreshToken = _authenticationService.GenerateRefreshToken();
            var token = _authenticationService.GenerateToken(existentUser);

            _userService.UpdateRefreshToken(existentUser, refreshToken);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return new()
            {
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<UserLoginResponseDTO?> Refresh(string refreshToken)
        {
            // TODO: Implement caching?

            var existentUser = await _unitOfWork.UserRepository.GetByRefreshTokenAsync(refreshToken);
            if (existentUser == null)
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.INVALID_REFRESH_TOKEN, string.Empty);
                return null;
            }

            var newRefreshToken = _authenticationService.GenerateRefreshToken();
            var newToken = _authenticationService.GenerateToken(existentUser);

            _userService.UpdateRefreshToken(existentUser, newRefreshToken);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return new()
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<UserPermissions?> PutUserPermissions(UpdateUserPermissionsDTO userPermissionsCreate)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canEdit;
            if (userAuthenticated != null)
                canEdit = _authorizationService.CanEdit(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            User? user = await _unitOfWork.UserRepository.GetByIdAsync(userPermissionsCreate.UserId);

            UserPermissions? userPermissions = await _userService.UpdateUserPermissions(userPermissionsCreate, user.UserPermission);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return userPermissions;
        }

        public async Task<UserPermissions?> DeleteUserPermissions(long id)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canDelete;
            if (userAuthenticated != null)
                canDelete = _authorizationService.CanDelete(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            UserPermissions? userPermissions = await _userService.DeleteUserPermissions(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return userPermissions;
        }

        public async Task<User?> CreateUserAdmin()
        {
            //criar utilizador do tipo admin
            CreateUserDTO userAdmin = new()
            {
                Email = "admin@gmail.com",
                Password = "admin",
                Username = "admin",
                RoleId = 1
            };

            User? user= await _userService.Create(userAdmin);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }
            return user;
        }

    }
}
