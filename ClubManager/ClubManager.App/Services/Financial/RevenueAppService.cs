using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using ClubManager.Domain.Services.Identity;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class RevenueAppService : IRevenueAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsService _userClaimsService;
        private readonly IRevenueService _revenueService;

        public RevenueAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserClaimsService userClaimsService, IRevenueService revenueService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userClaimsService = userClaimsService;
            _revenueService = revenueService;
        }

        public async Task<List<Revenue>?> CreateRevenue(CreateRevenueDTO revenueBody)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canCreate;
            if (userAuthenticated != null)
                canCreate = _authorizationService.CanCreate(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            List<Revenue>? revenueList = await _revenueService.CreateRevenue(revenueBody.Revenues);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return revenueList;
        }

        public async Task<Revenue?> DeleteRevenue(long id)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canDelete;
            if (userAuthenticated != null)
                canDelete = _authorizationService.CanDelete(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Revenue? revenueDeleted = await _revenueService.DeleteRevenue(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return revenueDeleted;
        }

        public async Task<List<Revenue>?> UpdateRevenue(UpdateEntityRevenueDTO revenueToUpdate)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canEdit;

            if (userAuthenticated != null)
                canEdit = _authorizationService.CanEdit(userAuthenticated.Id);
            else
            {
                _notificationContext.AddNotification(NotificationKeys.UserNotifications.USER_DONT_EXITS, string.Empty);
                return null;
            }

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Entity? entity = null;

            if (revenueToUpdate.Entity.Id != null)
                entity = await _unitOfWork.EntityRepository.GetById(revenueToUpdate.Entity.Id);

            if (entity == null)
            {
                _notificationContext.AddNotification(NotificationKeys.EntityNotifications.ENTITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            List<Revenue>? revenueList = await _revenueService.UpdateRevenue(revenueToUpdate.Revenues);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return revenueList;
        }

        public async Task<Entity?> GetRevenue(long revenueId)
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Entity? entity = await _unitOfWork.EntityRepository.GetRevenueWithEntity(revenueId);

            return entity;
        }

        public async Task<List<Entity>?> GetAllRevenue()
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _authorizationService.CanConsult(userAuthenticated.Id);

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Entity>? allEntity = await _unitOfWork.EntityRepository.GetAllRevenueWithEntity();

            return allEntity.ToList();
        }
    }
}
