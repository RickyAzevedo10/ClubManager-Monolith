using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Infrastructure
{
    public interface IAuthorizationService
    {
        Task<bool> CanEdit();
        Task<bool> CanConsult();
        Task<bool> CanDelete();
        Task<bool> CanCreate();
    }
}
