namespace ClubManager.Domain.DTOs.Identity
{
    public class UserLoginResponseDTO
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}
