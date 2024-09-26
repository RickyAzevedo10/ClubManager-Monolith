using AutoMapper;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class RevenueAppService : IRevenueAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IRevenueService _revenueService;
        private readonly IMapper _mapper;

        public RevenueAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IRevenueService revenueService, IMapper mapper)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _revenueService = revenueService;
            _mapper = mapper;
        }

        public async Task<RevenueResponseDTO?> CreateRevenue(RevenueDTO revenueBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Revenue? revenueList = await _revenueService.CreateRevenue(revenueBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<RevenueResponseDTO>(revenueList);
        }

        public async Task<RevenueResponseDTO?> DeleteRevenue(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Revenue? revenueDeleted = await _revenueService.DeleteRevenue(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<RevenueResponseDTO>(revenueDeleted);
        }

        public async Task<RevenueResponseDTO?> UpdateRevenue(UpdateRevenueDTO revenueToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Entity? entity = null;

            if (revenueToUpdate.EntityId != null)
                entity = await _unitOfWork.EntityRepository.GetById(revenueToUpdate.EntityId);

            if (entity == null)
            {
                _notificationContext.AddNotification(NotificationKeys.EntityNotifications.ENTITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            Revenue? revenue = await _revenueService.UpdateRevenue(revenueToUpdate);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return _mapper.Map<RevenueResponseDTO>(revenue);
        }

        public async Task<RevenueResponseDTO?> GetRevenue(long revenueId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Revenue? revenue = await _unitOfWork.RevenueRepository.GetById(revenueId);

            return _mapper.Map<RevenueResponseDTO>(revenue);
        }

        public async Task<List<RevenueResponseDTO>?> GetAllRevenue()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Revenue>? allRevenue = await _unitOfWork.RevenueRepository.GetAllAsync();

            return _mapper.Map<List<RevenueResponseDTO>>(allRevenue);
        }
    }
}
