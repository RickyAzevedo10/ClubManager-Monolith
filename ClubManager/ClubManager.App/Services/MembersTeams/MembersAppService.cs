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
    public class MembersAppService : IMembersAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMembersService _membersService;
        private readonly IMapper _mapper;

        public MembersAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, 
            IMembersService membersService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _membersService = membersService;
            _mapper = mapper;
        }

        #region ClubMember
        public async Task<ClubMemberResponseDTO?> Create(CreateClubMemberDTO memberToCreate)
        {
            bool canCreate = await _authorizationService.CanCreate();

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
                clubMember.UserClubMember = await _membersService.Create(memberToCreate.UserId, clubMember.Id);
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<ClubMemberResponseDTO>(clubMember); 
        }

        public async Task<ClubMemberResponseDTO?> Delete(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

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

            return _mapper.Map<ClubMemberResponseDTO>(clubMemberDeleted);
        }

        public async Task<List<ClubMemberResponseDTO>?> GetAllClubMembers()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<ClubMember>? clubMembers = await _unitOfWork.ClubMemberRepository.GetAllAsync();

            return _mapper.Map<List<ClubMemberResponseDTO>>(clubMembers);
        }

        public async Task<List<ClubMemberResponseDTO>?> SearchClubMembersAsync(string? firstName, string? lastName)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<ClubMember>? clubMembers = await _unitOfWork.ClubMemberRepository.SearchClubMembersAsync(firstName, lastName);

            return _mapper.Map<List<ClubMemberResponseDTO>>(clubMembers);
        }

        public async Task<ClubMemberResponseDTO?> Update(UpdateClubMemberDTO clubMemberToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            ClubMember? clubMember = null;
            
            if(clubMemberToUpdate.Id != 0)
                clubMember = await _unitOfWork.ClubMemberRepository.GetById((long)clubMemberToUpdate.Id);

            if (clubMember == null)
            {
                _notificationContext.AddNotification(NotificationKeys.ClubMemberNotifications.CLUBMEMBER_DONT_EXITS, string.Empty);
                return null;
            }

            clubMember = await _membersService.Update(clubMemberToUpdate, clubMember);

            if (clubMemberToUpdate.IsUser && clubMemberToUpdate.UserId != 0)
            {
                clubMember.UserClubMember = await _membersService.UpdateUserClubMember(clubMemberToUpdate.UserId, clubMember.Id);
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<ClubMemberResponseDTO>(clubMember);
        }
        #endregion

        #region MinorClubMember
        public async Task<MinorClubMemberResponseDTO?> CreateMinorClubMembers(CreateMinorClubMemberDTO minorMemberToCreate)
        {
            bool canCreate = await _authorizationService.CanCreate();

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

            return _mapper.Map<MinorClubMemberResponseDTO>(minorClubMember); 
        }

        public async Task<MinorClubMemberResponseDTO?> DeleteMinorClubMember(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

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

            return _mapper.Map<MinorClubMemberResponseDTO>(minorClubMemberDeleted);
        }

        public async Task<List<MinorClubMemberResponseDTO>?> GetAllMinorClubMembers()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<MinorClubMember>? minorClubMembers = await _unitOfWork.MinorClubMemberRepository.GetAllAsync();

            return _mapper.Map<List<MinorClubMemberResponseDTO>>(minorClubMembers);
        }

        public async Task<MinorClubMemberResponseDTO?> UpdateMinorMembers(UpdateMinorClubMemberDTO minorClubMemberToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            MinorClubMember? minorClubMember = null;

            if (minorClubMemberToUpdate.Id != null)
                minorClubMember = await _unitOfWork.MinorClubMemberRepository.GetById((long)minorClubMemberToUpdate.Id);

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

            return _mapper.Map<MinorClubMemberResponseDTO>(minorClubMember);
        }

        public async Task<List<MinorClubMemberResponseDTO>?> SearchMinorMembersAsync(string? firstName, string? lastName)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<MinorClubMember>? minorClubMembers = await _unitOfWork.MinorClubMemberRepository.SearchMinorClubMemberAsync(firstName, lastName);

            return _mapper.Map<List<MinorClubMemberResponseDTO>>(minorClubMembers);
        }
        #endregion
    }
}
