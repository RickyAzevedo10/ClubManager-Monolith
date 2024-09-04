namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class UpdatePlayerTransferDTO
    {
        public int? Id { get; set; }
        public int PlayerId { get; set; }
        public string FromClub { get; set; }
        public string ToClub { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
    }
}
