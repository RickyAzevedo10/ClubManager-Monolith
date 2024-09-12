using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.Domain.Services.Identity
{
    public class ExpenseService : IExpenseService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityValidationService _entityValidationService;
        private readonly IValidator<ExpenseDTO> _expenseValidator;
        private readonly IConfiguration _configuration;

        public ExpenseService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IConfiguration configuration, IEntityValidationService entityValidationService, IValidator<ExpenseDTO> expenseValidator)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _entityValidationService = entityValidationService;
            _expenseValidator = expenseValidator;
        }

        public async Task<Expense?> DeleteExpense(long id)
        {
            Expense? expense = await _unitOfWork.ExpenseRepository.GetById(id);

            if (expense == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ExpenseNotifications.EXPENSE_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            _unitOfWork.ExpenseRepository.Delete(expense);
            return expense;
        }

        public async Task<List<Expense>?> CreateExpense(List<ExpenseDTO> expenseBody)
        {
            List<Expense> expenses = [];
            
            foreach (var item in expenseBody)
            {
                bool validationResult = _entityValidationService.Validate(_expenseValidator, item);
                if (!validationResult)
                {
                    _notificationContext.AddNotification(NotificationKeys.ExpenseNotifications.ERROR_EXPENSE_CREATED, string.Empty);
                    return null;
                }
                Expense expense = new();
                expense.SetAmount(item.Amount);
                expense.SetCategoryId(item.CategoryId);
                expense.SetDescription(item.Description);
                expense.SetDestination(item.Destination);
                expense.SetPaymentReference(item.PaymentReference);
                expense.SetExpenseDate(item.ExpenseDate);
                expense.SetResponsibleUserId(item.ResponsibleUserId);
                expense.SetEntityId(item.EntityId);

                await _unitOfWork.ExpenseRepository.AddAsync(expense);
                expenses.Add(expense);
            }

            return expenses;
        }

        public async Task<List<Expense>?> UpdateExpense(List<UpdateExpenseDTO> expenseBody)
        {
            List<Expense>? listExpense = [];
            foreach (var item in expenseBody)
            {
                Expense expense = await _unitOfWork.ExpenseRepository.GetById(item.Id);
                ExpenseDTO expenseDTO = new()
                {
                    ExpenseDate = item.ExpenseDate,
                    Amount = item.Amount,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    Destination = item.Destination,
                    PaymentReference = item.PaymentReference,
                    EntityId = item.EntityId,
                    ResponsibleUserId = item.ResponsibleUserId
                };
                bool validationResult = _entityValidationService.Validate(_expenseValidator, expenseDTO);

                if (!validationResult && expense == null)
                {
                    _notificationContext.AddNotification(NotificationKeys.ExpenseNotifications.ERROR_EXPENSE_UPDATED, string.Empty);
                    return null;
                }

                expense.SetAmount(item.Amount);
                expense.SetCategoryId(item.CategoryId);
                expense.SetDescription(item.Description);
                expense.SetDestination(item.Destination);
                expense.SetPaymentReference(item.PaymentReference);
                expense.SetExpenseDate(item.ExpenseDate);
                expense.SetResponsibleUserId(item.ResponsibleUserId);
                expense.SetEntityId(item.EntityId);

                _unitOfWork.ExpenseRepository.Update(expense);
                listExpense.Add(expense);
            }
            return listExpense;
        }

    }
}
