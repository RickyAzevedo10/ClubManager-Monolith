using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Identity
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsService _userClaimsService;
        private readonly IPlayerService _playerService;

        public PlayerAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserClaimsService userClaimsService, IPlayerService playerService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userClaimsService = userClaimsService;
            _playerService = playerService;
        }

        #region Player
        public async Task<Player?> GetPlayer(long id)
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

            Player player = await _unitOfWork.PlayerRepository.GetById(id);

            return player;
        }

        public async Task<Player?> DeletePlayer(long id)
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

            Player? playerDeleted = await _playerService.DeletePlayer(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerDeleted;
        }

        public async Task<Player?> CreatePlayer(CreatePlayerDTO playerBody)
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
            
            Player? player = await _playerService.CreatePlayer(playerBody);

            if (player == null)
            {
                _notificationContext.AddNotification(NotificationKeys.PlayerNotifications.ERROR_PLAYER_CREATED, string.Empty);
                return null;
            }

            player.PlayerResponsibles = await _playerService.CreatePlayerResponsible(playerBody, player);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return player;
        }

        public async Task<Player?> UpdatePlayer(UpdatePlayerDTO playerToUpdate)
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

            Player? player = null;

            if (playerToUpdate.Id != null)
                player = await _unitOfWork.PlayerRepository.GetById(playerToUpdate.Id);

            if (player == null)
            {
                _notificationContext.AddNotification(NotificationKeys.PlayerNotifications.PLAYER_DONT_EXITS, string.Empty);
                return null;
            }

            player = await _playerService.UpdatePlayer(playerToUpdate, player);

            if (player == null)
            {
                _notificationContext.AddNotification(NotificationKeys.PlayerNotifications.ERROR_PLAYER_UPDATED, string.Empty);
                return null;
            }

            player.PlayerResponsibles = await _playerService.UpdatePlayerResponsible(playerToUpdate, player);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return player;
        }

        public async Task<List<Player>?> SearchPlayersAsync(string? firstName, string? lastName, string? position)
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

            IEnumerable<Player>? player = await _unitOfWork.PlayerRepository.SearchPlayersAsync(firstName, lastName, position);

            return player.ToList();
        }
        #endregion

        #region PlayerTransfer
        public async Task<List<PlayerTransfer>?> GetPlayerTransfer(long id)
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

            List<PlayerTransfer>? playerTransfer = await _unitOfWork.PlayerTransferRepository.GetAllPlayerTransferAsync(id);

            return playerTransfer;
        }

        public async Task<PlayerTransfer?> DeletePlayerTransfer(long id)
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

            PlayerTransfer? playerTransferDeleted = await _playerService.DeletePlayerTransfer(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerTransferDeleted;
        }

        public async Task<PlayerTransfer?> CreatePlayerTransfer(CreatePlayerTransferDTO playerTransferBody)
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

            PlayerTransfer? playerTransfer = await _playerService.CreatePlayerTransfer(playerTransferBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerTransfer;
        }

        public async Task<PlayerTransfer?> UpdatePlayerTransfer(UpdatePlayerTransferDTO playerTransferToUpdate)
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

            PlayerTransfer? playerTransfer = null;

            if (playerTransferToUpdate.Id != null)
                playerTransfer = await _unitOfWork.PlayerTransferRepository.GetById(playerTransferToUpdate.Id);

            if (playerTransfer == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_DONT_EXITS, string.Empty);
                return null;
            }

            playerTransfer = await _playerService.UpdatePlayerTransfer(playerTransferToUpdate, playerTransfer);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerTransfer;
        }
        #endregion

        #region PlayerContract
        public async Task<PlayerContract?> CreatePlayerContract(CreatePlayerContractDTO playerContractBody)
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

            List<PlayerContract>? listPlayerContract = await _unitOfWork.PlayerContractRepository.GetAllPlayerContractAsync(playerContractBody.PlayerId);

            if((listPlayerContract != null && listPlayerContract.Count > 1) || (listPlayerContract != null && listPlayerContract.Count == 1 && listPlayerContract.FirstOrDefault()!.EndDate > DateTime.Now))
            {
                _notificationContext.AddNotification(NotificationKeys.PlayerContractNotifications.PLAYER_ALREADY_HAVE_ACTIVE_CONTRACT, string.Empty);
                return null;
            }

            PlayerContract? playerContract = await _playerService.CreatePlayerContract(playerContractBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerContract;
        }

        public async Task<List<PlayerContract>?> GetPlayerContract(long id)
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

            List<PlayerContract>? playerContract = await _unitOfWork.PlayerContractRepository.GetAllPlayerContractAsync(id);

            return playerContract;
        }

        public async Task<PlayerContract?> DeletePlayerContract(long id)
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

            PlayerContract? playerContractDeleted = await _playerService.DeletePlayerContract(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerContractDeleted;
        }

        public async Task<PlayerContract?> UpdatePlayerContract(UpdatePlayerContractDTO playerContractToUpdate)
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

            PlayerContract? playerContract = null;

            if (playerContractToUpdate.Id != null)
                playerContract = await _unitOfWork.PlayerContractRepository.GetById(playerContractToUpdate.Id);

            if (playerContract == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_DONT_EXITS, string.Empty);
                return null;
            }

            playerContract = await _playerService.UpdatePlayerContract(playerContractToUpdate, playerContract);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerContract;
        }
        #endregion

        #region PlayerPerformanceHistory
        public async Task<PlayerPerformanceHistory?> DeletePlayerPerformanceHistory(long id)
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

            PlayerPerformanceHistory? playerPerformanceHistoryDeleted = await _playerService.DeletePlayerPerformanceHistory(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerPerformanceHistoryDeleted;
        }

        public async Task<PlayerPerformanceHistory?> CreatePlayerPerformanceHistory(CreatePlayerPerformanceHistoryDTO playerPerformanceHistoryBody)
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

            PlayerPerformanceHistory? playerPerformanceHistory = await _playerService.CreatePlayerPerformanceHistory(playerPerformanceHistoryBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerPerformanceHistory;
        }

        public async Task<PlayerPerformanceHistory?> UpdatePlayerPerformanceHistory(UpdatePlayerPerformanceHistoryDTO playerPerformanceHistoryToUpdate)
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

            PlayerPerformanceHistory? playerPerformanceHistory = null;

            if (playerPerformanceHistoryToUpdate.Id != null)
                playerPerformanceHistory = await _unitOfWork.PlayerPerformanceHistoryRepository.GetById(playerPerformanceHistoryToUpdate.Id);

            if (playerPerformanceHistory == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_DONT_EXITS, string.Empty);
                return null;
            }

            playerPerformanceHistory = await _playerService.UpdatePlayerPerformanceHistory(playerPerformanceHistoryToUpdate, playerPerformanceHistory);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return playerPerformanceHistory;
        }

        public async Task<PlayerPerformanceHistoryResponseDTO?> GetPlayerPerformanceHistory(long playerId, string season)
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

            List<PlayerPerformanceHistory>? allPlayerPerformanceHistoryOfPlayer = await _unitOfWork.PlayerPerformanceHistoryRepository.GetAllPlayerPerformanceHistoryForSeasonAsync(playerId, season);

            PlayerPerformanceHistoryResponseDTO response = new();

            if (allPlayerPerformanceHistoryOfPlayer!= null && allPlayerPerformanceHistoryOfPlayer.Any())
            {
                response.Season = season;
                response.NumberOfGoals = allPlayerPerformanceHistoryOfPlayer.Sum(p => p.Goals);
                response.NumberOfAssists = allPlayerPerformanceHistoryOfPlayer.Sum(p => p.Assists);
                response.NumberOfMinutesPlayed = allPlayerPerformanceHistoryOfPlayer.Sum(p => p.MinutesPlayed);
                response.NumberOfMatchesPlayed = allPlayerPerformanceHistoryOfPlayer.Count;
                response.NumberOfYellowCards = allPlayerPerformanceHistoryOfPlayer.Sum(p => p.YellowCards);
                response.NumberOfRedCards = allPlayerPerformanceHistoryOfPlayer.Sum(p => p.RedCards);
            }

            return response;
        }
        #endregion

    }
}
