using AutoMapper;
using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.TrainingCompetition;
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
        private readonly ITrainingService _trainingService;
        private readonly IMapper _mapper;

        public TrainingAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, 
            ITrainingService trainingService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _trainingService = trainingService;
            _mapper = mapper;
        }

        #region TrainingSession
        public async Task<TrainingSessionResponseDTO?> CreateTrainingSession(CreateTrainingSessionDTO trainingSessionBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

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

            return _mapper.Map<TrainingSessionResponseDTO>(trainingSession); 
        }

        public async Task<TrainingSessionResponseDTO?> DeleteTrainingSession(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

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

            return _mapper.Map<TrainingSessionResponseDTO>(trainingSessionDeleted); 
        }

        public async Task<TrainingSessionResponseDTO?> GetTrainingSession(long trainingSessionId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            TrainingSession trainingSession = await _unitOfWork.TrainingSessionRepository.GetById(trainingSessionId);

            return _mapper.Map<TrainingSessionResponseDTO>(trainingSession);
        }

        public async Task<TrainingSessionResponseDTO?> UpdateTrainingSession(UpdateTrainingSessionDTO trainingSessionToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

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

            return _mapper.Map<TrainingSessionResponseDTO>(trainingSession);
        }

        public async Task<List<TrainingSessionResponseDTO>?> GetTrainingSessionsByDateRange(DateTime startDate, DateTime endDate)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<TrainingSession> trainingSession = await _unitOfWork.TrainingSessionRepository.GetTrainingSessionsByDateRangeAsync(startDate, endDate);

            return _mapper.Map<List<TrainingSessionResponseDTO>>(trainingSession);
        }
        #endregion

        #region TrainingAttendance
        public async Task<TrainingAttendanceResponseDTO?> CreateTrainingAttendance(CreateTrainingAttendanceDTO trainingAttendanceBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

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

            return _mapper.Map<TrainingAttendanceResponseDTO>(trainingAttendance); 
        }

        public async Task<TrainingAttendanceResponseDTO?> DeleteTrainingAttendance(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

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

            return _mapper.Map<TrainingAttendanceResponseDTO>(trainingAttendanceDeleted);
        }

        public async Task<TrainingAttendanceResponseDTO?> UpdateTrainingAttendance(UpdateTrainingAttendanceDTO trainingAttendanceToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

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

            return _mapper.Map<TrainingAttendanceResponseDTO>(trainingAttendance);
        }

        public async Task<List<TrainingAttendanceResponseDTO>?> GetTrainingAttendance(long trainingAttendanceId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<TrainingAttendance>? trainingAttendance = await _unitOfWork.TrainingAttendanceRepository.GetTrainingAttendanceByPlayerId(trainingAttendanceId);

            return _mapper.Map<List<TrainingAttendanceResponseDTO>>(trainingAttendance);
        }
        #endregion
    }
}
