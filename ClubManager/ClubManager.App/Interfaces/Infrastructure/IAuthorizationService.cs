using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Infrastructure
{
    public interface IAuthorizationService
    {
        bool CanEdit(long userId);
        bool CanConsult(long userId);
        bool CanDelete(long userId);
        bool CanCreate(long userId);
    }
}
