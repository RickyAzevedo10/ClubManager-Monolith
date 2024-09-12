namespace ClubManager.Domain.DTOs.Identity
{
    public class ResetPassword
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }
    }
}
