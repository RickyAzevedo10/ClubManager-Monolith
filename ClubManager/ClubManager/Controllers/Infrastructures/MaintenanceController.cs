using ClubManager.App.Services.Infrastructures;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Interfaces;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly IMaintenanceAppService _maintenanceAppService;

        public MaintenanceController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, IMaintenanceAppService maintenanceAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _maintenanceAppService = maintenanceAppService;
        }

        #region MaintenanceRequest
        /// <summary>
        /// create MaintenanceRequest
        /// </summary>
        /// <param name="maintenanceRequestBody"></param>
        /// <returns></returns>
        [HttpPost("MaintenanceRequest")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas")]
        public async Task<IActionResult> PostMaintenanceRequest([FromBody] CreateMaintenanceRequestDTO maintenanceRequestBody)
        {
            MaintenanceRequestResponseDTO? response = await _maintenanceAppService.CreateMaintenanceRequest(maintenanceRequestBody);
            return DomainResult<MaintenanceRequestResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get MaintenanceRequest
        /// </summary>
        /// <param name="maintenanceRequestId"></param>
        /// <returns></returns>
        [HttpGet("MaintenanceRequest")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> GetMaintenanceRequest([FromQuery] long maintenanceRequestId)
        {
            MaintenanceRequestResponseDTO? response = await _maintenanceAppService.GetMaintenanceRequest(maintenanceRequestId);
            return DomainResult<MaintenanceRequestResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete MaintenanceRequest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("MaintenanceRequest")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas")]
        public async Task<IActionResult> DeleteMaintenanceRequest([FromQuery] long id)
        {
            MaintenanceRequestResponseDTO? response = await _maintenanceAppService.DeleteMaintenanceRequest(id);
            return DomainResult<MaintenanceRequestResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update MaintenanceRequest
        /// </summary>
        /// <param name="maintenanceRequestToUpdate"></param>
        /// <returns></returns>
        [HttpPut("MaintenanceRequest")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas")]
        public async Task<IActionResult> PutMaintenanceRequest([FromBody] UpdateMaintenanceRequestDTO maintenanceRequestToUpdate)
        {
            MaintenanceRequestResponseDTO? response = await _maintenanceAppService.UpdateMaintenanceRequest(maintenanceRequestToUpdate);
            return DomainResult<MaintenanceRequestResponseDTO?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion

        #region MaintenanceHistory
        /// <summary>
        /// create MaintenanceHistory
        /// </summary>
        /// <param name="maintenanceRequestId"></param>
        /// <returns></returns>
        [HttpPost("MaintenanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> PostMaintenanceHistory([FromQuery] long maintenanceRequestId)
        {
            MaintenanceHistory? response = await _maintenanceAppService.CreateMaintenanceHistory(maintenanceRequestId);
            return DomainResult<MaintenanceHistory?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get MaintenanceHistory
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("MaintenanceHistory")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> GetMaintenanceHistory([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            List<MaintenanceHistory>? response = await _maintenanceAppService.GetMaintenanceHistory(startDate, endDate);
            return DomainResult<List<MaintenanceHistory>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion

    }
}
