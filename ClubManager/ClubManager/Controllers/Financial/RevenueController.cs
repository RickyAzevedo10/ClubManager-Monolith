using ClubManager.App.Services.Infrastructures;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Interfaces;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly IRevenueAppService _revenueAppService;

        public RevenueController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, IRevenueAppService revenueAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _revenueAppService = revenueAppService;
        }

        /// <summary>
        /// create Revenue
        /// </summary>
        /// <param name="revenueBody"></param>
        /// <returns></returns>
        [HttpPost("Revenue")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PostRevenue(CreateRevenueDTO revenueBody)
        {
            List<Revenue>? response = await _revenueAppService.CreateRevenue(revenueBody);
            return DomainResult<List<Revenue>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update Revenue
        /// </summary>
        /// <param name="revenueToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Revenue")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PutRevenue(UpdateEntityRevenueDTO revenueToUpdate)
        {
            List<Revenue>? response = await _revenueAppService.UpdateRevenue(revenueToUpdate);
            return DomainResult<List<Revenue>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete Revenue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Revenue")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> DeleteRevenue(long id)
        {
            Revenue? response = await _revenueAppService.DeleteRevenue(id);
            return DomainResult<Revenue?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get Revenue
        /// </summary>
        /// <param name="revenueId"></param>
        /// <returns></returns>
        [HttpGet("RevenueId")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetRevenue(long revenueId)
        {
            Entity? response = await _revenueAppService.GetRevenue(revenueId);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all revenues
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllRevenue")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetAllRevenue()
        {
            List<Entity>? response = await _revenueAppService.GetAllRevenue();
            return DomainResult<List<Entity>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
    }
}
