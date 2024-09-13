using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IExpenseService _expenseService;

        public ExpenseAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IExpenseService expenseService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _expenseService = expenseService;
        }

        public async Task<List<Expense>?> CreateExpense(CreateExpenseDTO expenseBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            List<Expense>? expenseList = await _expenseService.CreateExpense(expenseBody.Expenses);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return expenseList;
        }

        public async Task<Expense?> DeleteExpense(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Expense? facilityDeleted = await _expenseService.DeleteExpense(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facilityDeleted;
        }

        public async Task<List<Expense>?> UpdateExpense(UpdateEntityExpenseDTO expenseToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Entity? entity = null;

            if (expenseToUpdate.Entity.Id != null)
                entity = await _unitOfWork.EntityRepository.GetById(expenseToUpdate.Entity.Id);

            if (entity == null)
            {
                _notificationContext.AddNotification(NotificationKeys.EntityNotifications.ENTITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            List<Expense>? expenseList = await _expenseService.UpdateExpense(expenseToUpdate.Expenses);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return expenseList;
        }

        public async Task<Entity?> GetExpense(long expenseId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Entity? entity = await _unitOfWork.EntityRepository.GetExpenseWithEntity(expenseId);

            return entity;
        }

        public async Task<List<Entity>?> GetAllExpense()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Entity>? allEntity = await _unitOfWork.EntityRepository.GetAllExpenseWithEntity();

            return allEntity.ToList();
        }

    }
}
