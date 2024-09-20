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
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionAppService _institutionAppService;
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        
        public InstitutionController(IInstitutionAppService institutionAppService, INotificationContext notificationContext, IModelErrorsContext modelErrorsContext)
        {
            _institutionAppService = institutionAppService;
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
        }

        /// <summary>
        /// Get a specific institution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Institution/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(long id)
        {
            Institution? response = await _institutionAppService.Get(id);
            return DomainResult<Institution?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Get all institution
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllInstitution")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            List<Institution>? response = await _institutionAppService.GetAll();
            return DomainResult<List<Institution>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Create a new institution and a admin user for that institution
        /// </summary>
        /// <param name="institutionBody"></param>
        /// <returns></returns>
        [HttpPost("Institution")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateInstitutionDTO institutionBody)
        {
            Institution? response = await _institutionAppService.Create(institutionBody);
            return DomainResult<Institution?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Update a institution
        /// </summary>
        /// <param name="institutionToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Institution")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateInstitutionDTO institutionToUpdate)
        {
            Institution? response = await _institutionAppService.Update(institutionToUpdate);
            return DomainResult<Institution?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// Delete a specific institution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Institution")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            Institution? response = await _institutionAppService.Delete(id);
            return DomainResult<Institution?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
    }
}
