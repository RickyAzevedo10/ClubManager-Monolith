using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Identity
{
    public class TrainingAppService : ITrainingAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsService _userClaimsService;
        private readonly ITrainingService _trainingService;

        public TrainingAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserClaimsService userClaimsService, ITrainingService trainingService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userClaimsService = userClaimsService;
            _trainingService = trainingService;
        }

        #region TrainingSession
        public async Task<TrainingSession?> CreateTrainingSession(CreateTrainingSessionDTO trainingSessionBody)
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

            TrainingSession? trainingSession = await _trainingService.CreateTrainingSession(trainingSessionBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingSession;
        }
        public async Task<TrainingSession?> DeleteTrainingSession(long id)
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

            TrainingSession? trainingSessionDeleted = await _trainingService.DeleteTrainingSession(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingSessionDeleted;
        }

        public async Task<TrainingSession?> GetTrainingSession(long trainingSessionId)
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

            TrainingSession trainingSession = await _unitOfWork.TrainingSessionRepository.GetById(trainingSessionId);

            return trainingSession;
        }

        public async Task<TrainingSession?> UpdateTrainingSession(UpdateTrainingSessionDTO trainingSessionToUpdate)
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

            TrainingSession? trainingSession = null;

            if (trainingSessionToUpdate.Id != null)
                trainingSession = await _unitOfWork.TrainingSessionRepository.GetById(trainingSessionToUpdate.Id);

            if (trainingSession == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TrainingSessionNotifications.TRAINING_SESSION_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            trainingSession = await _trainingService.UpdateTrainingSession(trainingSessionToUpdate, trainingSession);

            if (trainingSession == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TrainingSessionNotifications.ERROR_TRAINING_SESSION_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingSession;
        }

        public async Task<List<TrainingSession>?> GetTrainingSessionsByDateRange(DateTime startDate, DateTime endDate)
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

            List<TrainingSession> trainingSession = await _unitOfWork.TrainingSessionRepository.GetTrainingSessionsByDateRangeAsync(startDate, endDate);

            return trainingSession;
        }
        #endregion

        #region TrainingAttendance
        public async Task<TrainingAttendance?> CreateTrainingAttendance(CreateTrainingAttendanceDTO trainingAttendanceBody)
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

            TrainingAttendance? trainingAttendance = await _trainingService.CreateTrainingAttendance(trainingAttendanceBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingAttendance;
        }

        public async Task<TrainingAttendance?> DeleteTrainingAttendance(long id)
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

            TrainingAttendance? trainingAttendanceDeleted = await _trainingService.DeleteTrainingAttendance(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingAttendanceDeleted;
        }

        public async Task<TrainingAttendance?> UpdateTrainingAttendance(UpdateTrainingAttendanceDTO trainingAttendanceToUpdate)
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

            TrainingAttendance? trainingAttendance = null;

            if (trainingAttendanceToUpdate.Id != null)
                trainingAttendance = await _unitOfWork.TrainingAttendanceRepository.GetById(trainingAttendanceToUpdate.Id);

            if (trainingAttendance == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TrainingAttendanceNotifications.TRAINING_ATTENDANCE_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            trainingAttendance = await _trainingService.UpdateTrainingAttendance(trainingAttendanceToUpdate, trainingAttendance);

            if (trainingAttendance == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TrainingAttendanceNotifications.ERROR_TRAINING_ATTENDANCE_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return trainingAttendance;
        }

        public async Task<List<TrainingAttendance>?> GetTrainingAttendance(long trainingAttendanceId)
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

            List<TrainingAttendance>? trainingAttendance = await _unitOfWork.TrainingAttendanceRepository.GetTrainingAttendanceByPlayerId(trainingAttendanceId);

            return trainingAttendance;
        }
        #endregion
    }
}
