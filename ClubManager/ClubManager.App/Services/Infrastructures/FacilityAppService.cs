using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Infrastructures;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class FacilityAppService : IFacilityAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IFacilityService _facilityService;

        public FacilityAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IFacilityService facilityService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _facilityService = facilityService;
        }

        #region Facility
        public async Task<Facility?> GetFacility(long facilityId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Facility? facility = await _unitOfWork.FacilityRepository.GetById(facilityId);

            return facility;  
        }

        public async Task<List<Facility>?> GetAllFacility()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Facility>? allFacility = await _unitOfWork.FacilityRepository.GetAllAsync();

            return allFacility.ToList();
        }

        public async Task<Facility?> DeleteFacility(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Facility? facilityDeleted = await _facilityService.DeleteFacility(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facilityDeleted;
        }
        
        public async Task<Facility?> CreateFacility(CreateFacilityDTO facilityBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Facility? facility = await _facilityService.CreateFacility(facilityBody);


            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facility;
        }

        public async Task<Facility?> UpdateFacility(UpdateFacilityDTO facilityToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Facility? facility = null;

            if (facilityToUpdate.Id != null)
                facility = await _unitOfWork.FacilityRepository.GetById(facilityToUpdate.Id);

            if (facility == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityNotifications.FACILITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            facility = await _facilityService.UpdateFacility(facilityToUpdate, facility);

            if (facility == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityNotifications.ERROR_FACILITY_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facility;
        }
        #endregion

        #region FacilityReservation
        public async Task<FacilityReservation?> GetFacilityReservation(long facilityReservationId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            FacilityReservation? facilityReservation = await _unitOfWork.FacilityReservationRepository.GetById(facilityReservationId);

            return facilityReservation;
        }

        public async Task<FacilityReservation?> DeleteFacilityReservation(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            FacilityReservation? facilityReservationDeleted = await _facilityService.DeleteFacilityReservation(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facilityReservationDeleted;
        }

        public async Task<FacilityReservation?> CreateFacilityReservation(CreateFacilityReservationDTO facilityReservationBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            FacilityReservation? facilityReservation = await _facilityService.CreateFacilityReservation(facilityReservationBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facilityReservation;
        }

        public async Task<FacilityReservation?> UpdateFacilityReservation(UpdateFacilityReservationDTO facilityReservationToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            FacilityReservation? facilityReservation = null;

            if (facilityReservationToUpdate.Id != null)
                facilityReservation = await _unitOfWork.FacilityReservationRepository.GetById(facilityReservationToUpdate.Id);

            if (facilityReservation == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityReservationNotifications.FACILITY_RESERVATION_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            facilityReservation = await _facilityService.UpdateFacilityReservation(facilityReservationToUpdate, facilityReservation);

            if (facilityReservation == null)
            {
                _notificationContext.AddNotification(NotificationKeys.FacilityNotifications.ERROR_FACILITY_UPDATED, string.Empty);
                return null;
            }

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return facilityReservation;
        }
        #endregion
    }
}
