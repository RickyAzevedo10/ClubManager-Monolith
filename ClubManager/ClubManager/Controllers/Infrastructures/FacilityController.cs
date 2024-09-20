using ClubManager.App.Services.Infrastructures;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly IFacilityAppService _facilityAppService;

        public FacilityController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, IFacilityAppService facilityAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _facilityAppService = facilityAppService;
        }

        #region Facility
        /// <summary>
        /// create Facility
        /// </summary>
        /// <param name="facilityBody"></param>
        /// <returns></returns>
        [HttpPost("Facility")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> PostFacility(CreateFacilityDTO facilityBody)
        {
            Facility? response = await _facilityAppService.CreateFacility(facilityBody);
            return DomainResult<Facility?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get Facility
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        [HttpGet("FacilityId")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> GetFacility(long facilityId)
        {
            Facility? response = await _facilityAppService.GetFacility(facilityId);  
            return DomainResult<Facility?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all Facility
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllFacility")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> GetAllFacility()
        {
            List<Facility>? response = await _facilityAppService.GetAllFacility();
            return DomainResult<List<Facility>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete Facility
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Facility")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> DeleteFacility(long id)
        {
            Facility? response = await _facilityAppService.DeleteFacility(id);
            return DomainResult<Facility?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update Facility
        /// </summary>
        /// <param name="facilityToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Facility")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> PutFacility(UpdateFacilityDTO facilityToUpdate)
        {
            Facility? response = await _facilityAppService.UpdateFacility(facilityToUpdate);
            return DomainResult<Facility?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion

        #region FacilityReservation
        /// <summary>
        /// create FacilityReservation
        /// </summary>
        /// <param name="facilityReservationBody"></param>
        /// <returns></returns>
        [HttpPost("FacilityReservation")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> PostFacilityReservation(CreateFacilityReservationDTO facilityReservationBody)
        {
            FacilityReservation? response = await _facilityAppService.CreateFacilityReservation(facilityReservationBody);
            return DomainResult<FacilityReservation?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get FacilityReservation
        /// </summary>
        /// <param name="facilityReservationId"></param>
        /// <returns></returns>
        [HttpGet("FacilityReservation")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> GetFacilityReservation(long facilityReservationId)
        {
            FacilityReservation? response = await _facilityAppService.GetFacilityReservation(facilityReservationId);
            return DomainResult<FacilityReservation?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete FacilityReservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("FacilityReservation")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> DeleteFacilityReservation(long id)
        {
            FacilityReservation? response = await _facilityAppService.DeleteFacilityReservation(id);
            return DomainResult<FacilityReservation?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update FacilityReservation
        /// </summary>
        /// <param name="facilityReservationToUpdate"></param>
        /// <returns></returns>
        [HttpPut("FacilityReservation")]
        [Authorize(Roles = "Admin,Presidente,Gestor de Infraestruturas,Secretário")]
        public async Task<IActionResult> PutFacilityReservation(UpdateFacilityReservationDTO facilityReservationToUpdate)
        {
            FacilityReservation? response = await _facilityAppService.UpdateFacilityReservation(facilityReservationToUpdate);
            return DomainResult<FacilityReservation?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion

    }
}
