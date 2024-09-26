using AutoMapper;
using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Identity
{
    public class TeamAppService : ITeamAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, ITeamService teamService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _teamService = teamService;
            _mapper = mapper;
        }

        public async Task<List<TeamResponseDTO>?> GetTeams()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Team>? allTeams = await _unitOfWork.TeamRepository.GetAllAsync();

            return _mapper.Map<List<TeamResponseDTO>>(allTeams);
        }

        public async Task<List<TeamResponseDTO>?> GetAllPlayersFromTeam(long teamId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<Team>? allTeams = await _unitOfWork.TeamRepository.GetAllPlayerFromTeamAsync(teamId);

            return _mapper.Map<List<TeamResponseDTO>>(allTeams);
        }

        public async Task<TeamResponseDTO?> DeleteTeam(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Team? teamDeleted = await _teamService.DeleteTeam(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<TeamResponseDTO>(teamDeleted); 
        }

        public async Task<TeamResponseDTO?> CreateTeam(CreateTeamDTO teamBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Team? team = await _teamService.CreateTeam(teamBody);
            if (_notificationContext.HasNotifications())
            {
                return null;
            }

            team.TeamCoaches = await _teamService.CreateTeamCoach(teamBody.TeamCoachDTO, team);
            team.TeamPlayers = await _teamService.CreateTeamPlayer(teamBody.PlayerId, team);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<TeamResponseDTO>(team);
        }

        public async Task<TeamResponseDTO?> UpdateTeam(UpdateTeamDTO teamToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Team? team = null;

            if (teamToUpdate.Id != null)
                team = await _unitOfWork.TeamRepository.GetById((long)teamToUpdate.Id);

            if (team == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TeamNotifications.TEAM_DONT_EXITS, string.Empty);
                return null;
            }

            team = await _teamService.UpdateTeam(teamToUpdate, team);

            if (team == null || _notificationContext.HasNotifications())
                return null;

            team.TeamCoaches = await _teamService.UpdateTeamCoaches(teamToUpdate, team);
            team.TeamPlayers = await _teamService.UpdateTeamPlayers(teamToUpdate, team);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<TeamResponseDTO>(team);
        }
    }
}
