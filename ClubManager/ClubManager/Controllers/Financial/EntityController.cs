using ClubManager.App.Services.Infrastructures;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;
        private readonly ModelErrorsContext _modelErrorsContext;
        private readonly IEntityAppService _entityAppService;
        public EntityController(NotificationContext notificationContext, ModelErrorsContext modelErrorsContext, IEntityAppService entityAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _entityAppService = entityAppService;
        }

        /// <summary>
        /// create Entity
        /// </summary>
        /// <param name="entityBody"></param>
        /// <returns></returns>
        [HttpPost("Entity")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PostExpense(CreateEntityDTO entityBody)
        {
            Entity? response = await _entityAppService.CreateEntity(entityBody);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Entity")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> DeleteEntity(long id)
        {
            Entity? response = await _entityAppService.DeleteEntity(id);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update Entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Entity")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PutEntity(UpdateEntityDTO entityToUpdate)
        {
            Entity? response = await _entityAppService.UpdateEntity(entityToUpdate);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get Entity
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("Entity")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetEntity(long entityId)
        {
            Entity? response = await _entityAppService.GetEntity(entityId);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all Entity
        /// </summary>
        /// <returns></returns>
        [HttpGet("Entity")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetAllEntity()
        {
            List<Entity>? response = await _entityAppService.GetAllEntity();
            return DomainResult<List<Entity>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
    }
}
