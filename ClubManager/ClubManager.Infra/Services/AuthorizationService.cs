using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.Interfaces.Repositories;

namespace ClubManager.Infra.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CanEdit(long userId)
        {
            return _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userId).FirstOrDefault()?.Edit ?? false;
        }

        public bool CanConsult(long userId)
        {
            return _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userId).FirstOrDefault()?.Consult ?? false;
        }

        public bool CanDelete(long userId)
        {
            return _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userId).FirstOrDefault()?.Delete ?? false;
        }

        public bool CanCreate(long userId)
        {
            return _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userId).FirstOrDefault()?.Create ?? false;
        }
    }
}
