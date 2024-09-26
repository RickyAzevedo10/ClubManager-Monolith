using AutoMapper;
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
        private readonly IMapper _mapper;

        public ExpenseAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IExpenseService expenseService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public async Task<ExpenseResponseDTO?> CreateExpense(ExpenseDTO expenseBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Expense? expense = await _expenseService.CreateExpense(expenseBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<ExpenseResponseDTO>(expense);
        }

        public async Task<ExpenseResponseDTO?> DeleteExpense(long id)
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

            return _mapper.Map<ExpenseResponseDTO>(facilityDeleted);
        }

        public async Task<ExpenseResponseDTO> UpdateExpense(UpdateExpenseDTO expenseToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Entity? entity = null;

            if (expenseToUpdate.EntityId != null)
                entity = await _unitOfWork.EntityRepository.GetById(expenseToUpdate.EntityId);

            if (entity == null)
            {
                _notificationContext.AddNotification(NotificationKeys.EntityNotifications.ENTITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            Expense? expenseUpdated = await _expenseService.UpdateExpense(expenseToUpdate);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<ExpenseResponseDTO>(expenseUpdated); 
        }

        public async Task<ExpenseResponseDTO?> GetExpense(long expenseId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Expense? expense = await _unitOfWork.ExpenseRepository.GetById(expenseId);

            return _mapper.Map<ExpenseResponseDTO>(expense); 
        }

        public async Task<List<ExpenseResponseDTO>?> GetAllExpense()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Expense>? allExpenses = await _unitOfWork.ExpenseRepository.GetAllAsync();

            return _mapper.Map<List<ExpenseResponseDTO>>(allExpenses);
        }

    }
}
