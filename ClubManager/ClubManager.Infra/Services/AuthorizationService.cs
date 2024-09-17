using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Interfaces.Repositories;

namespace ClubManager.Infra.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserClaimsService _userClaimsService;

        public AuthorizationService(IUnitOfWork unitOfWork, IUserClaimsService userClaimsService)
        {
            _unitOfWork = unitOfWork;
            _userClaimsService = userClaimsService;
        }

        public async Task<bool> CanEdit()
        {
            User? userAuthenticated = await GetUserAuthenticated();

            bool canEdit = false;

            if (userAuthenticated != null)
                canEdit = _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userAuthenticated.Id).FirstOrDefault()?.Edit ?? false;

            return canEdit;
        }

        public async Task<bool> CanConsult()
        {
            User? userAuthenticated = await GetUserAuthenticated();

            bool canConsult = false;

            if (userAuthenticated != null)
                canConsult = _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userAuthenticated.Id).FirstOrDefault()?.Consult ?? false;

            return canConsult;
        }

        public async Task<bool> CanDelete()
        {
            User? userAuthenticated = await GetUserAuthenticated();

            bool canDelete = false;

            if (userAuthenticated != null)
                canDelete = _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userAuthenticated.Id).FirstOrDefault()?.Delete ?? false;

            return canDelete;
        }

        public async Task<bool> CanCreate()
        {
            User? userAuthenticated = await GetUserAuthenticated();

            bool canCreate = false;

            if (userAuthenticated != null)
                canCreate = _unitOfWork.UserPermissionsRepository.GetEntity().Where(x => x.Users.FirstOrDefault()!.Id == userAuthenticated.Id).FirstOrDefault()?.Create ?? false;

            return canCreate;
        }

        private async Task<User?> GetUserAuthenticated()
        {
            string? email = _userClaimsService.GetUserEmail();
            User? userAuthenticated = null;

            if (email != null)
                userAuthenticated = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            return userAuthenticated;
        }
    }
}
