using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity.Validators;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.Domain.Services.Identity
{
    public class RevenueService : IRevenueService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityValidationService _entityValidationService;
        private readonly IValidator<RevenueDTO> _revenueValidator;

        public RevenueService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IEntityValidationService entityValidationService, IValidator<RevenueDTO> revenueValidator)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _entityValidationService = entityValidationService;
            _revenueValidator = revenueValidator;
        }

        public async Task<List<Revenue>?> CreateRevenue(List<RevenueDTO> revenueBody)
        {
            List<Revenue> revenues = [];

            foreach (var item in revenueBody)
            {
                bool validationResult = _entityValidationService.Validate(_revenueValidator, item);
                if (!validationResult)
                {
                    _notificationContext.AddNotification(NotificationKeys.ExpenseNotifications.ERROR_EXPENSE_CREATED, string.Empty);
                    return null;
                }
                Revenue revenue = new();
                revenue.SetAmount(item.Amount);
                revenue.SetRevenueDate(item.RevenueDate);
                revenue.SetSource(item.Source);
                revenue.SetCategoryId(item.CategoryId);
                revenue.SetDescription(item.Description);
                revenue.SetPaymentReference(item.PaymentReference);
                revenue.SetEntityId(item.EntityId);

                await _unitOfWork.RevenueRepository.AddAsync(revenue);
                revenues.Add(revenue);
            }

            return revenues;
        }

        public async Task<List<Revenue>?> UpdateRevenue(List<RevenueDTO> revenueBody)
        {
            List<Revenue>? listRevenue = [];
            foreach (var item in revenueBody)
            {
                Revenue revenue = await _unitOfWork.RevenueRepository.GetById(item.Id);
                RevenueDTO revenueDTO = new()
                {
                    RevenueDate = item.RevenueDate,
                    Source = item.Source,
                    Amount = item.Amount,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    PaymentReference = item.PaymentReference,
                    EntityId = item.EntityId,
                    ResponsibleUserId = item.ResponsibleUserId
                };

                bool validationResult = _entityValidationService.Validate(_revenueValidator, revenueDTO);

                if (!validationResult && revenue == null)
                {
                    _notificationContext.AddNotification(NotificationKeys.ExpenseNotifications.ERROR_EXPENSE_UPDATED, string.Empty);
                    return null;
                }

                revenue.SetAmount(item.Amount);
                revenue.SetRevenueDate(item.RevenueDate);
                revenue.SetSource(item.Source);
                revenue.SetCategoryId(item.CategoryId);
                revenue.SetDescription(item.Description);
                revenue.SetPaymentReference(item.PaymentReference);
                revenue.SetEntityId(item.EntityId);

                _unitOfWork.RevenueRepository.Update(revenue);
                listRevenue.Add(revenue);
            }
            return listRevenue;
        }

        public async Task<Revenue?> DeleteRevenue(long id)
        {
            Revenue? revenue = await _unitOfWork.RevenueRepository.GetById(id);

            if (revenue == null)
            {
                _notificationContext.AddNotification(NotificationKeys.RevenueNotifications.REVENUE_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            _unitOfWork.RevenueRepository.Delete(revenue);
            return revenue;
        }
    }
}
