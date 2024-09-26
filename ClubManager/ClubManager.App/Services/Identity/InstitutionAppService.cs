using AutoMapper;
using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Identity
{
    public class InstitutionAppService : IInstitutionAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IInstitutionService _institutionService;
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public InstitutionAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IInstitutionService institutionService, IUserAppService userAppService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _institutionService = institutionService;
            _userAppService = userAppService;
            _mapper = mapper;
        }

        public async Task<InstitutionResponseDTO?> Get(long id)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if(!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Institution? institution = await _institutionService.Get(id);
            return _mapper.Map<InstitutionResponseDTO>(institution);
        }

        public async Task<List<InstitutionResponseDTO>?> GetAll()
        {
            bool canConsult = await _authorizationService.CanConsult();
            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<Institution>? institution = await _institutionService.GetAll();
            return _mapper.Map<List<InstitutionResponseDTO>>(institution);
        }

        public async Task<InstitutionResponseDTO?> Create(CreateInstitutionDTO institutionBody)
        {
            Institution? institution = await _unitOfWork.InstitutionRepository.GetByNameAsync(institutionBody.Name);

            if(institution != null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_ALREADY_EXITS, string.Empty);
                return null;
            }

            institution = await _institutionService.Create(institutionBody);

            User? userAdmin = await _userAppService.CreateUserAdmin(institutionBody.Abbreviation);

            if (userAdmin != null && institution != null)
            {
                institution.User.Add(userAdmin);
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<InstitutionResponseDTO>(institution);
        }

        public async Task<InstitutionResponseDTO?> Update(UpdateInstitutionDTO institutionToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();
            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Institution? institution = await _unitOfWork.InstitutionRepository.GetById(institutionToUpdate.Id);

            if (institution == null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_NOT_FOUND, string.Empty);
                return null;
            }

            institution = await _institutionService.Update(institutionToUpdate, institution);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<InstitutionResponseDTO>(institution);
        }

        public async Task<InstitutionResponseDTO?> Delete(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();
            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Institution? institution = await _institutionService.Delete(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<InstitutionResponseDTO>(institution);
        }
    }
}
