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
    public class ExpenseController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;
        private readonly ModelErrorsContext _modelErrorsContext;
        private readonly IExpenseAppService _expenseAppService;
        public ExpenseController(NotificationContext notificationContext, ModelErrorsContext modelErrorsContext, IExpenseAppService expenseAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _expenseAppService = expenseAppService;
        }

        /// <summary>
        /// create expense
        /// </summary>
        /// <param name="expenseBody"></param>
        /// <returns></returns>
        [HttpPost("Expense")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PostExpense(CreateExpenseDTO expenseBody)
        {
            List<Expense>? response = await _expenseAppService.CreateExpense(expenseBody);
            return DomainResult<List<Expense>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete Expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Expense")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> DeleteExpense(long id)
        {
            Expense? response = await _expenseAppService.DeleteExpense(id);
            return DomainResult<Expense?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update expense
        /// </summary>
        /// <param name="expenseToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Expense")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> PutExpense(UpdateEntityExpenseDTO expenseToUpdate)
        {
            List<Expense>? response = await _expenseAppService.UpdateExpense(expenseToUpdate);
            return DomainResult<List<Expense>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get expense
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [HttpGet("Expense")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetExpense(long expenseId)
        {
            Entity? response = await _expenseAppService.GetExpense(expenseId);
            return DomainResult<Entity?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all expense
        /// </summary>
        /// <returns></returns>
        [HttpGet("Expense")]
        [Authorize(Roles = "Admin,Presidente,Diretor Financeiro,Secretário")]
        public async Task<IActionResult> GetAllExpense()
        {
            List<Entity>? response = await _expenseAppService.GetAllExpense();
            return DomainResult<List<Entity>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
    }
}
