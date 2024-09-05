using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Infrastructures;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class MaintenanceAppService : IMaintenanceAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsService _userClaimsService;
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserClaimsService userClaimsService, IMaintenanceService maintenanceService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userClaimsService = userClaimsService;
            _maintenanceService = maintenanceService;
        }

        #region MaintenanceRequest
        public async Task<MaintenanceRequest?> GetMaintenanceRequest(long maintenanceRequestId)
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

            MaintenanceRequest? maintenanceRequest = await _unitOfWork.MaintenanceRequestRepository.GetById(maintenanceRequestId);

            return maintenanceRequest;
        }

        public async Task<MaintenanceRequest?> DeleteMaintenanceRequest(long id)
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

            MaintenanceRequest? maintenanceRequestDeleted = await _maintenanceService.DeleteMaintenanceRequest(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return maintenanceRequestDeleted;
        }

        public async Task<MaintenanceRequest?> CreateMaintenanceRequest(CreateMaintenanceRequestDTO maintenanceRequestBody)
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

            MaintenanceRequest? maintenanceRequest = await _maintenanceService.CreateMaintenanceRequest(maintenanceRequestBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return maintenanceRequest;
        }

        public async Task<MaintenanceRequest?> UpdateMaintenanceRequest(UpdateMaintenanceRequestDTO maintenanceRequestToUpdate)
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

            MaintenanceRequest? maintenanceRequest = null;

            if (maintenanceRequestToUpdate.Id != null)
                maintenanceRequest = await _unitOfWork.MaintenanceRequestRepository.GetById(maintenanceRequestToUpdate.Id);

            if (maintenanceRequest == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityNotifications.FACILITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            maintenanceRequest = await _maintenanceService.UpdateMaintenanceRequest(maintenanceRequestToUpdate, maintenanceRequest);

            if (maintenanceRequest == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityNotifications.ERROR_FACILITY_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return maintenanceRequest;
        }
        #endregion

        #region MaintenanceHistory
        public async Task<MaintenanceHistory?> CreateMaintenanceHistory(long maintenanceRequestId)
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

            MaintenanceHistory? maintenanceHistory = await _maintenanceService.CreateMaintenanceHistory(maintenanceRequestId);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return maintenanceHistory;
        }

        public async Task<List<MaintenanceHistory>?> GetMaintenanceHistory(DateTime startDate, DateTime endDate)
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

            if ((startDate > endDate) || (startDate > DateTime.Now || endDate > DateTime.Now))
            {
                _notificationContext.AddNotification(NotificationKeys.MaintenanceHistoryNotifications.MAINTENANCE_HISTORY_DATETIME_INVALID, string.Empty);
                return null;
            }

            List<MaintenanceHistory>? listMaintenanceHistory = await _unitOfWork.MaintenanceHistoryRepository.GetMaintenanceHistoryByDateRange(startDate, endDate);

            return listMaintenanceHistory;
        }

        #endregion
    }
}
