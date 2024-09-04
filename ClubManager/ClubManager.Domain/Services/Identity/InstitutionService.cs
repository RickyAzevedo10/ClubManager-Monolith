using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using FluentValidation;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.Domain.Services.Identity
{
    public class InstitutionService : IInstitutionService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityValidationService _entityValidationService;
        private readonly IValidator<Institution> _institutionValidator;


        public InstitutionService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IEntityValidationService entityValidationService, IValidator<Institution> institutionValidator)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _entityValidationService = entityValidationService;
            _institutionValidator = institutionValidator;
        }

        public async Task<Institution?> Get(long id)
        {
            Institution? institution = await _unitOfWork.InstitutionRepository.GetByIdAsync(id);

            if (institution == null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_NOT_FOUND, string.Empty);
                return null;
            }
            return institution;
        }

        public async Task<List<Institution>?> GetAll()
        {
            List<Institution>? institutions = await _unitOfWork.InstitutionRepository.GetAllAsync();

            if (institutions == null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_NOT_FOUND, string.Empty);
                return null;
            }
            return institutions;
        }

        public async Task<Institution?> Create(Institution institutionBody)
        {
            bool validationResult = _entityValidationService.Validate(_institutionValidator, institutionBody);
            if (!validationResult)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.ERROR_INSTITUTION_CREATED, string.Empty);
                return null;
            }

            Institution institution = new(institutionBody);

            return await _unitOfWork.InstitutionRepository.AddAsync(institution);
        }

        public async Task<Institution?> Update(Institution institutionToUpdate)
        {
            bool validationResult = _entityValidationService.Validate(_institutionValidator, institutionToUpdate);
            if (!validationResult)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.ERROR_INSTITUTION_CREATED, string.Empty);
                return null;
            }
 
            _unitOfWork.InstitutionRepository.Update(institutionToUpdate);
            return institutionToUpdate;
        }

        public async Task<Institution?> Delete(long id)
        {
            Institution? institution = await _unitOfWork.InstitutionRepository.GetByIdAsync(id);

            if (institution == null)
            {
                _notificationContext.AddNotification(NotificationKeys.InstitutionNotifications.INSTITUTION_NOT_FOUND, string.Empty);
                return null;
            }

            _unitOfWork.InstitutionRepository.Delete(institution);

            return institution;
        }
    }
}
