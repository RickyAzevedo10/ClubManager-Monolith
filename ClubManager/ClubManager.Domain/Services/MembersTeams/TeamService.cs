using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.Domain.Services.Identity
{
    public class TeamService : ITeamService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityValidationService _entityValidationService;
        private readonly IConfiguration _configuration;
        private readonly IValidator<CreateTeamDTO> _createTeamValidator;
        private readonly IValidator<UpdateTeamDTO> _updateTeamValidator;

        public TeamService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IConfiguration configuration, 
            IEntityValidationService entityValidationService, IValidator<CreateTeamDTO> createTeamValidator, IValidator<UpdateTeamDTO> updateTeamValidator)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _entityValidationService = entityValidationService;
            _createTeamValidator = createTeamValidator;
            _updateTeamValidator = updateTeamValidator;
        }

        public async Task<Team?> DeleteTeam(long id)
        {
            Team? team = await _unitOfWork.TeamRepository.GetById(id);

            if (team == null)
            {
                _notificationContext.AddNotification(NotificationKeys.TeamNotifications.TEAM_DONT_EXITS, string.Empty);
                return null;
            }

            _unitOfWork.TeamRepository.Delete(team);
            return team;
        }

        public async Task<Team?> CreateTeam(CreateTeamDTO teamBody)
        {
            bool validationResult = _entityValidationService.Validate(_createTeamValidator, teamBody);
            if (!validationResult)
            {
                _notificationContext.AddNotification(NotificationKeys.TeamNotifications.ERROR_TEAM_CREATED, string.Empty);
                return null;
            }

            Team team = new();
            team.SetMale(teamBody.Male);
            team.SetName(teamBody.Name);
            team.SetFemale(teamBody.Female);
            team.SetClubId(teamBody.ClubId);
            team.SetTeamCategoryId(teamBody.TeamCategoryId);

            return await _unitOfWork.TeamRepository.AddAsync(team);
        }

        public async Task<List<TeamCoach>?> CreateTeamCoach(List<CreateTeamCoachDTO> teamCoachBody, Team team)
        {
            List<TeamCoach> teamCoachs = [];

            foreach (var item in teamCoachBody)
            {
                User user = await _unitOfWork.UserRepository.GetById(item.UserId);
                if (user == null)
                {
                    _notificationContext.AddNotification(NotificationKeys.TeamNotifications.ERROR_TEAM_CREATED, string.Empty);
                    return null;
                }
                TeamCoach teamCoach = new();
                teamCoach.SetTeamId((int)team.Id);
                teamCoach.SetUserId(item.UserId);
                teamCoach.SetIsHeadCoach(item.IsHeadCoach);

                await _unitOfWork.TeamCoachRepository.AddAsync(teamCoach);
                teamCoachs.Add(teamCoach);
            }
            return teamCoachs;
        }

        public async Task<List<TeamPlayer>?> CreateTeamPlayer(List<long> teamBody, Team team)
        {
            List<TeamPlayer> teamPlayers = [];

            foreach (var playerId in teamBody)
            {
                Player player = await _unitOfWork.PlayerRepository.GetById(playerId);
                if (player == null)
                {
                    _notificationContext.AddNotification(NotificationKeys.TeamNotifications.ERROR_TEAM_CREATED, string.Empty);
                    return null;
                }
                TeamPlayer teamPlayer = new();
                teamPlayer.SetTeamId((int)team.Id);
                teamPlayer.SetPlayerId((int)playerId);

                await _unitOfWork.TeamPlayerRepository.AddAsync(teamPlayer);
                teamPlayers.Add(teamPlayer);
            }
            return teamPlayers;
        }

        public async Task<Team?> UpdateTeam(UpdateTeamDTO teamToUpdate, Team team)
        {
            bool validationResult = _entityValidationService.Validate(_updateTeamValidator, teamToUpdate);
            if (!validationResult)
            {
                _notificationContext.AddNotification(NotificationKeys.TeamNotifications.ERROR_TEAM_UPDATED, string.Empty);
                return null;
            }
            team.SetMale(teamToUpdate.Male);
            team.SetName(teamToUpdate.Name);
            team.SetFemale(teamToUpdate.Female);
            team.SetClubId(teamToUpdate.ClubId);
            team.SetTeamCategoryId(teamToUpdate.TeamCategoryId);

            _unitOfWork.TeamRepository.Update(team);
            return team;
        }

        public async Task<List<TeamCoach>?> UpdateTeamCoaches(UpdateTeamDTO teamToUpdate, Team team)
        {
            await _unitOfWork.TeamCoachRepository.DeleteAllAsync();

            return await CreateTeamCoach(teamToUpdate.TeamCoachDTO, team);
        }

        public async Task<List<TeamPlayer>?> UpdateTeamPlayers(UpdateTeamDTO teamToUpdate, Team team)
        {
            await _unitOfWork.TeamCoachRepository.DeleteAllAsync();

            return await CreateTeamPlayer(teamToUpdate.PlayerId, team);
        }

    }
}
