using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using static ClubManager.Domain.Constants.Constants;

namespace ClubManager.App.Services.Infrastructures
{
    public class EntityAppService : IEntityAppService
    {
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationService _authorizationService;
        private readonly IEntityService _entityService;

        public EntityAppService(INotificationContext notificationContext, IUnitOfWork unitOfWork, IAuthorizationService authorizationService, IEntityService entityService)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _authorizationService = authorizationService;
            _entityService = entityService;
        }

        public async Task<Entity?> CreateEntity(CreateEntityDTO entityBody)
        {
            bool canCreate = await _authorizationService.CanCreate();

            if (!canCreate)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CREATE, string.Empty);
                return null;
            }

            Entity? entity = await _entityService.CreateEntity(entityBody);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return entity;
        }

        public async Task<Entity?> DeleteEntity(long id)
        {
            bool canDelete = await _authorizationService.CanDelete();

            if (!canDelete)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_DELETE, string.Empty);
                return null;
            }

            Entity? entityDeleted = await _entityService.DeleteEntity(id);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return entityDeleted;
        }

        public async Task<Entity?> UpdateEntity(UpdateEntityDTO entityToUpdate)
        {
            bool canEdit = await _authorizationService.CanEdit();

            if (!canEdit)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_EDIT, string.Empty);
                return null;
            }

            Entity? entity = null;

            if (entityToUpdate.Id != null)
                entity = await _unitOfWork.EntityRepository.GetById(entityToUpdate.Id);

            if (entity == null)
            {
                _notificationContext.AddNotification(NotificationKeys.EntityNotifications.ENTITY_DOES_NOT_EXIST, string.Empty);
                return null;
            }

            entity = await _entityService.UpdateEntity(entityToUpdate, entity);

            if (!await _unitOfWork.CommitAsync())
            {
                _notificationContext.AddNotification(NotificationKeys.DATABASE_COMMIT_ERROR, string.Empty);
                return null;
            }

            return entity;
        }

        public async Task<Entity?> GetEntity(long entityId)
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            Entity? entity = await _unitOfWork.EntityRepository.GetById(entityId);

            return entity;
        }

        public async Task<List<Entity>?> GetAllEntity()
        {
            bool canConsult = await _authorizationService.CanConsult();

            if (!canConsult)
            {
                _notificationContext.AddNotification(NotificationKeys.CANT_CONSULT, string.Empty);
                return null;
            }

            IEnumerable<Entity>? allEntity = await _unitOfWork.EntityRepository.GetAllAsync();

            return allEntity.ToList();
        }
    }
}
