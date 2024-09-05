using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace ClubManager.Domain.Entities.Identity
{
    public class User : BaseEntity
    {
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorActivated { get; set; } = false;
        public int AccessFailedCount { get; set; } = 0;
        public DateTime? LockoutEnd { get; set; }
        public DateTime? DateOfLastAccess { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpire { get; set; }
        public int UserRoleId { get; set; }
        public UserRoles UserRole { get; set; }  
        public int UserPermissionId { get; set; }
        public UserPermissions UserPermission { get; set; }
        public UserClubMember UserClubMember { get; set; }

        public ICollection<TeamCoach> TeamCoaches { get; set; }
        public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }
        public ICollection<MaintenanceHistory> MaintenanceHistory { get; set; }
        public ICollection<FacilityReservation> FacilityReservation { get; set; }


        // Construtor necessário para EF
        private User(){}

        public User(CreateUserDTO user)
        {
            Email = user.Email;
            SetPassword(user.Password);
            Username = user.Username;
            UserRoleId = user.RoleId;
        }

        public void UpdateRefreshToken(string refreshToken, int expiresHours)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpire = DateTime.UtcNow.AddHours(expiresHours);
        }

        public void SetPassword(string password)
        {
            using var hmac = new HMACSHA256();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidatePassword(string password)
        {
            using var hmac = new HMACSHA256(PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, PasswordHash);
        }
    }
}
