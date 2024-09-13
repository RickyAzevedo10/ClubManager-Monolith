using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
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

        public InstitutionAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IInstitutionService institutionService, IUserAppService userAppService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _institutionService = institutionService;
            _userAppService = userAppService;
        }

        public async Task<Institution?> Get(long id)
        {
            //validar se tem permissões para consultar
            bool canConsult = await _authorizationService.CanConsult();

            if(!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Institution? institution = await _institutionService.Get(id);
            return institution;
        }

        public async Task<List<Institution>?> GetAll()
        {
            bool canConsult = await _authorizationService.CanConsult();
            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            List<Institution>? institution = await _institutionService.GetAll();
            return institution;
        }

        public async Task<Institution?> Create(Institution institutionBody)
        {
            //validar se ja existe a instituição
            Institution? institution = await _unitOfWork.InstitutionRepository.GetByNameAsync(institutionBody.Name);

            if(institution != null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_ALREADY_EXITS, string.Empty);
                return null;
            }

            institution = await _institutionService.Create(institutionBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            await _userAppService.CreateUserAdmin();

            return institution;
        }

        public async Task<Institution?> Update(Institution institutionToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();
            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            //validar se ja existe a instituição
            Institution? institution = await _unitOfWork.InstitutionRepository.GetByNameAsync(institutionToUpdate.Name);

            if (institution == null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_NOT_FOUND, string.Empty);
                return null;
            }

            institution = await _institutionService.Update(institutionToUpdate);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return institution;
        }

        public async Task<Institution?> Delete(long id)
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

            return institution;
        }
    }
}
