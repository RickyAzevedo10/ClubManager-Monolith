using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Infrastructure
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
    }
}
