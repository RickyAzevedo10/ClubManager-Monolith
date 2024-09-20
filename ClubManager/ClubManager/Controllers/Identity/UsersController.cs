using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.Identity
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;

        public UsersController(IUserAppService userAppService, INotificationContext notificationContext, IModelErrorsContext modelErrorsContext)
        {
            _modelErrorsContext = modelErrorsContext;
            _userAppService = userAppService;
            _notificationContext = notificationContext;
        }

        /// <summary>
        /// get user information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("User/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            User? response = await _userAppService.Get(id);
            return DomainResult<User?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all information about a institution id
        /// </summary>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [HttpGet("User/Institution")]
        [Authorize]
        public async Task<IActionResult> GetAllFromInstitution(long idInstitution)
        {
            List<User>? response = await _userAppService.GetAllFromInstitution(idInstitution);
            return DomainResult<List<User>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get user permissions from a user id
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("UserPermissions/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserPermissions(long idUser)
        {
            List<UserPermissions>? response = await _userAppService.GetUserPermissions(idUser);
            return DomainResult<List<UserPermissions>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// roles existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserRoles")]
        [Authorize]
        public async Task<IActionResult> GetAllUserRoles()
        {
            List<UserRoles>? response = await _userAppService.GetAllUserRoles();
            return DomainResult<List<UserRoles>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="userBody"></param>
        /// <returns></returns>
        [HttpPost("User")]
        [Authorize]
        public async Task<IActionResult> Post(CreateUserDTO userBody)
        {
            User? response = await _userAppService.Create(userBody);
            return DomainResult<User?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns></returns>
        [HttpPut("User")]
        [Authorize]
        public async Task<IActionResult> Put(CreateUserDTO userToUpdate)
        {
            User? response = await _userAppService.Update(userToUpdate);
            return DomainResult<User?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("User")]
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            User? response = await _userAppService.Delete(id);
            return DomainResult<User?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser(UserLoginDTO user)
        {
            UserLoginResponseDTO result = await _userAppService.Login(user);
            return DomainResult<UserLoginResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpGet("Refresh/{refreshToken}")]
        [Authorize]
        public async Task<IActionResult> RefreshUser(string refreshToken)
        {
            UserLoginResponseDTO result = await _userAppService.Refresh(refreshToken);
            return DomainResult<UserLoginResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update User Permissions
        /// </summary>
        /// <param name="userPermissionsBody"></param>
        /// <returns></returns>
        [HttpPut("UserPermissions")]
        [Authorize]
        public async Task<IActionResult> PutUserPermissions(UpdateUserPermissionsDTO userPermissionsBody)
        {
            UserPermissions? response = await _userAppService.PutUserPermissions(userPermissionsBody);
            return DomainResult<UserPermissions?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Delete User Permissions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("UserPermissions")]
        [Authorize]
        public async Task<IActionResult> DeleteUserPermissions(long id)
        {
            UserPermissions? response = await _userAppService.DeleteUserPermissions(id);
            return DomainResult<UserPermissions?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Recover password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Recover-password")]
        [AllowAnonymous]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordRequest request)
        {
            RecoverPasswordRequestResponse? result = await _userAppService.RecoverPassword(request);
            return DomainResult<RecoverPasswordRequestResponse?>.Ok(result, _notificationContext, _modelErrorsContext);
        }
         
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword request)
        {
            ResetPasswordResponse? result = await _userAppService.ResetPassword(request);
            return DomainResult<ResetPasswordResponse?>.Ok(result, _notificationContext, _modelErrorsContext);
        }
    }
}
