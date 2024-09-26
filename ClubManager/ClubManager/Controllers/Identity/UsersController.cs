using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.Identity;
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
        [HttpGet("User")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            UserResponseDTO? response = await _userAppService.Get(id);
            return DomainResult<UserResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all information about a institution id
        /// </summary>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [HttpGet("User/Institution")]
        [Authorize]
        public async Task<IActionResult> GetAllFromInstitution([FromQuery] long idInstitution)
        {
            List<UserResponseDTO>? response = await _userAppService.GetAllFromInstitution(idInstitution);
            return DomainResult<List<UserResponseDTO>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get user permissions from a user id
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("UserPermissions")]
        [Authorize]
        public async Task<IActionResult> GetUserPermissions([FromQuery] long idUser)
        {
            List<UserPermissionResponseDTO>? response = await _userAppService.GetUserPermissions(idUser);
            return DomainResult<List<UserPermissionResponseDTO>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// roles existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserRoles")]
        [Authorize]
        public async Task<IActionResult> GetAllUserRoles()
        {
            List<UserRoleResponseDTO>? response = await _userAppService.GetAllUserRoles();
            return DomainResult<List<UserRoleResponseDTO>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="userBody"></param>
        /// <returns></returns>
        [HttpPost("User")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO userBody)
        {
            UserResponseDTO? response = await _userAppService.Create(userBody);
            return DomainResult<UserResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns></returns>
        [HttpPut("User")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateUserDTO userToUpdate)
        {
            UserResponseDTO? response = await _userAppService.Update(userToUpdate);
            return DomainResult<UserResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("User")]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            UserResponseDTO? response = await _userAppService.Delete(id);
            return DomainResult<UserResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO user)
        {
            UserLoginResponseDTO? result = await _userAppService.Login(user);
            return DomainResult<UserLoginResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpGet("RefreshToken")]
        [Authorize]
        public async Task<IActionResult> RefreshUser([FromQuery] string refreshToken)
        {
            UserLoginResponseDTO? result = await _userAppService.Refresh(refreshToken);
            return DomainResult<UserLoginResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update User Permissions
        /// </summary>
        /// <param name="userPermissionsBody"></param>
        /// <returns></returns>
        [HttpPut("UserPermissions")]
        [Authorize]
        public async Task<IActionResult> PutUserPermissions([FromBody] UpdateUserPermissionsDTO userPermissionsBody)
        {
            UserPermissionResponseDTO? response = await _userAppService.PutUserPermissions(userPermissionsBody);
            return DomainResult<UserPermissionResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Delete User Permissions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("UserPermissions")]
        [Authorize]
        public async Task<IActionResult> DeleteUserPermissions([FromQuery] long id)
        {
            UserPermissionResponseDTO? response = await _userAppService.DeleteUserPermissions(id);
            return DomainResult<UserPermissionResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Recover password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Recover-password")]
        [AllowAnonymous]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordRequestDTO request)
        {
            RecoverPasswordRequestResponseDTO? result = await _userAppService.RecoverPassword(request);
            return DomainResult<RecoverPasswordRequestResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }
         
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO request)
        {
            ResetPasswordResponseDTO? result = await _userAppService.ResetPassword(request);
            return DomainResult<ResetPasswordResponseDTO?>.Ok(result, _notificationContext, _modelErrorsContext);
        }
    }
}
