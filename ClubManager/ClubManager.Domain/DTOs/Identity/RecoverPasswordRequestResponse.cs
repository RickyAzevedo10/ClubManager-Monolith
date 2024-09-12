namespace ClubManager.Domain.DTOs.Identity
{
    public class RecoverPasswordRequestResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
