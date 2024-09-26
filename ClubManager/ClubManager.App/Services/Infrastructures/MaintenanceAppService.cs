using AutoMapper;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Infrastructures;
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
        private readonly IMaintenanceService _maintenanceService;
        private readonly IMapper _mapper;

        public MaintenanceAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, 
            IMaintenanceService maintenanceService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _maintenanceService = maintenanceService;
            _mapper = mapper;
        }

        #region MaintenanceRequest
        public async Task<MaintenanceRequestResponseDTO?> GetMaintenanceRequest(long maintenanceRequestId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            MaintenanceRequest? maintenanceRequest = await _unitOfWork.MaintenanceRequestRepository.GetById(maintenanceRequestId);

            return _mapper.Map<MaintenanceRequestResponseDTO>(maintenanceRequest); 
        }

        public async Task<MaintenanceRequestResponseDTO?> DeleteMaintenanceRequest(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

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

            return _mapper.Map<MaintenanceRequestResponseDTO>(maintenanceRequestDeleted); 
        }

        public async Task<MaintenanceRequestResponseDTO?> CreateMaintenanceRequest(CreateMaintenanceRequestDTO maintenanceRequestBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

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

            return _mapper.Map<MaintenanceRequestResponseDTO>(maintenanceRequest); 
        }

        public async Task<MaintenanceRequestResponseDTO?> UpdateMaintenanceRequest(UpdateMaintenanceRequestDTO maintenanceRequestToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

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

            return _mapper.Map<MaintenanceRequestResponseDTO>(maintenanceRequest);
        }
        #endregion

        #region MaintenanceHistory
        public async Task<MaintenanceHistory?> CreateMaintenanceHistory(long maintenanceRequestId)
        {
            bool canCreate = await _authorizationService.CanCreate();

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
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            if (startDate > endDate)
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
