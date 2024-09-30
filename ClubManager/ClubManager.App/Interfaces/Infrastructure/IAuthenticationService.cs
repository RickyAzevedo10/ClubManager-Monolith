using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.App.Interfaces.Infrastructure
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserCacheInformationDTO user);
        string GenerateRefreshToken();
    }
}
