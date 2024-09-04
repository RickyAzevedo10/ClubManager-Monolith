using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClubManager.Infra.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            IEnumerable<Claim> claims =
            [
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Role, user.UserRole.Name)
            ];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));

            SigningCredentials signingCredential = new(
            securityKey,
            SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(Double.Parse(_configuration.GetSection("Jwt:ExpiresMin").Value!)),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCredential);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
