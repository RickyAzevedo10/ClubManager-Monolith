namespace ClubManager.Domain.DTOs.Identity
{
    public class RecoverPasswordRequestResponseDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
