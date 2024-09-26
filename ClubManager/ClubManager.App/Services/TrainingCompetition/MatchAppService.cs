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
    public class MatchAppService : IMatchAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IMatchService matchAppService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _matchService = matchAppService;
            _mapper = mapper;
        }

        #region Match
        public async Task<MatchResponseDTO?> CreateMatch(CreateMatchDTO matchBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Match? match = await _matchService.CreateMatch(matchBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchResponseDTO>(match); 
        }

        public async Task<MatchResponseDTO?> DeleteMatch(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Match? matchDeleted = await _matchService.DeleteMatch(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchResponseDTO>(matchDeleted);
        }

        public async Task<MatchResponseDTO?> GetMatch(long matchId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Match match = await _unitOfWork.MatchRepository.GetById(matchId);

            return _mapper.Map<MatchResponseDTO>(match); 
        }

        public async Task<List<MatchResponseDTO>?> GetTeamMatches(long teamId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<Match>? match = await _unitOfWork.MatchRepository.GetMachesByTeamId(teamId);

            return _mapper.Map<List<MatchResponseDTO>>(match);
        }

        public async Task<MatchResponseDTO?> UpdateMatch(UpdateMatchDTO matchToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Match? match = null;

            if (matchToUpdate.Id != null)
                match = await _unitOfWork.MatchRepository.GetById((long)matchToUpdate.Id);

            if (match == null)
            {
                _notificationContext.AddNotification(NotificationKeys.MatchNotifications.MATCH_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            match = await _matchService.UpdateMatch(matchToUpdate, match);

            if (match == null)
            {
                _notificationContext.AddNotification(NotificationKeys.MatchNotifications.ERROR_MATCH_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchResponseDTO>(match);
        }
        #endregion

        #region MatchStatistics
        public async Task<MatchStatisticResponseDTO?> CreateMatchStatistic(CreateMatchStatisticDTO matchStatisticBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            MatchStatistic? matchStatistic = await _matchService.CreateMatchStatistic(matchStatisticBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchStatisticResponseDTO>(matchStatistic);
        }

        public async Task<MatchStatisticResponseDTO?> UpdateMatchStatistic(UpdateMatchStatisticDTO matchStatisticToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            MatchStatistic? matchStatistic = null;

            if (matchStatisticToUpdate.Id != null)
                matchStatistic = await _unitOfWork.MatchStatisticRepository.GetById(matchStatisticToUpdate.Id);

            if (matchStatistic == null)
            {
                _notificationContext.AddNotification(NotificationKeys.MatchStatisticNotifications.MATCH_STATISTIC_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            matchStatistic = await _matchService.UpdateMatchStatistic(matchStatisticToUpdate, matchStatistic);

            if (matchStatistic == null)
            {
                _notificationContext.AddNotification(NotificationKeys.MatchStatisticNotifications.ERROR_MATCH_STATISTIC_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchStatisticResponseDTO>(matchStatistic);
        }

        public async Task<MatchStatisticResponseDTO?> DeleteMatchStatistic(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            MatchStatistic? matchStatisticDeleted = await _matchService.DeleteMatchStatistic(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<MatchStatisticResponseDTO>(matchStatisticDeleted);
        }

        public async Task<List<MatchStatisticResponseDTO>?> GetMatchStatisticsFromMatchID(long matchId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<MatchStatistic>? matchStatisticsList = await _unitOfWork.MatchStatisticRepository.GetMatchStatisticsFromMatchID(matchId);

            return _mapper.Map<List<MatchStatisticResponseDTO>>(matchStatisticsList);
        }

        public async Task<List<MatchStatisticResponseDTO>?> GetPlayerMatchStatistics(long playerId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<MatchStatistic>? matchStatisticsList = await _unitOfWork.MatchStatisticRepository.GetPlayerMatchStatistics(playerId);

            return _mapper.Map<List<MatchStatisticResponseDTO>>(matchStatisticsList); 
        }

        public async Task<List<MatchStatisticResponseDTO>?> GetPlayerMatchStatisticsFromMatchId(long playerId, long matchId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<MatchStatistic>? matchStatisticsList = await _unitOfWork.MatchStatisticRepository.GetPlayerMatchStatisticsFromMatchId(playerId, matchId);

            return _mapper.Map<List<MatchStatisticResponseDTO>>(matchStatisticsList);
        }
        #endregion
    }
}
