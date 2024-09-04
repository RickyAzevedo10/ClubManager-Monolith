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
    public class MembersAppService : IMembersAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsService _userClaimsService;
        private readonly IMembersService _membersService;

        public MembersAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IUserClaimsService userClaimsService, IMembersService membersService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _userClaimsService = userClaimsService;
            _membersService = membersService;
        }

        #region ClubMember
        public async Task<ClubMember?> Create(CreateClubMemberDTO memberToCreate)
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

            ClubMember? clubMember = await _unitOfWork.ClubMemberRepository.GetByEmailAsync(memberToCreate.Email);

            if (clubMember != null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_ALREADY_EXITS, string.Empty);
                return null;
            }

            clubMember = await _membersService.Create(memberToCreate);

            if(memberToCreate.IsUser && memberToCreate.UserId != 0)
            {
                //TODO:create registo no userclubmember
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return clubMember;
        }

        public async Task<ClubMember?> Delete(long id)
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

            ClubMember? clubMemberDeleted = await _membersService.Delete(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return clubMemberDeleted;
        }

        public async Task<List<ClubMember>?> GetAllClubMembers()
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

            IEnumerable<ClubMember>? clubMembers = await _unitOfWork.ClubMemberRepository.GetAllAsync();

            return clubMembers.ToList();
        }

        public async Task<List<ClubMember>?> SearchClubMembersAsync(string? firstName, string? lastName)
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

            IEnumerable<ClubMember>? clubMembers = await _unitOfWork.ClubMemberRepository.SearchClubMembersAsync(firstName, lastName);

            return clubMembers.ToList();
        }

        public async Task<ClubMember?> Update(UpdateClubMemberDTO clubMemberToUpdate)
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

            ClubMember? clubMember = null;
            
            if(clubMemberToUpdate.ClubMemberId != null)
                clubMember = await _unitOfWork.ClubMemberRepository.GetById(clubMemberToUpdate.ClubMemberId);

            if (clubMember == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_DONT_EXITS, string.Empty);
                return null;
            }

            clubMember = await _membersService.Update(clubMemberToUpdate, clubMember);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return clubMember;
        }
        #endregion

        #region MinorClubMember
        public async Task<MinorClubMember?> CreateMinorClubMembers(CreateMinorClubMemberDTO minorMemberToCreate)
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

            MinorClubMember? minorClubMember = await _unitOfWork.MinorClubMemberRepository.GetByEmailAsync(minorMemberToCreate.Email);

            if (minorClubMember != null)
            {
                _notificationContext.AddNotification(NotificationKeys.MinorClubMemberNotifications.MINORCLUBMEMBER_ALREADY_EXISTS, string.Empty);
                return null;
            }

            minorClubMember = await _membersService.CreateMinorClubMember(minorMemberToCreate);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return minorClubMember;
        }

        public async Task<MinorClubMember?> DeleteMinorClubMember(long id)
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

            MinorClubMember? minorClubMemberDeleted = await _membersService.DeleteMinorClubMember(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return minorClubMemberDeleted;
        }

        public async Task<List<MinorClubMember>?> GetAllMinorClubMembers()
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

            IEnumerable<MinorClubMember>? minorClubMembers = await _unitOfWork.MinorClubMemberRepository.GetAllAsync();

            return minorClubMembers.ToList();
        }

        public async Task<MinorClubMember?> UpdateMinorMembers(UpdateMinorClubMemberDTO minorClubMemberToUpdate)
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

            MinorClubMember? minorClubMember = null;

            if (minorClubMemberToUpdate.MinorClubMemberId != null)
                minorClubMember = await _unitOfWork.MinorClubMemberRepository.GetById(minorClubMemberToUpdate.MinorClubMemberId);

            if (minorClubMember == null)
            {
                _notificationContext.AddNotification(NotificationKeys.MinorClubMemberNotifications.MINORCLUBMEMBER_DONT_EXIST, string.Empty);
                return null;
            }

            minorClubMember = await _membersService.UpdateMinorClubMember(minorClubMemberToUpdate, minorClubMember);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return minorClubMember;
        }

        public async Task<List<MinorClubMember>?> SearchMinorMembersAsync(string? firstName, string? lastName)
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

            IEnumerable<MinorClubMember>? minorClubMembers = await _unitOfWork.MinorClubMemberRepository.SearchMinorClubMemberAsync(firstName, lastName);

            return minorClubMembers.ToList();
        }
        #endregion
    }
}
