namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class UpdatePlayerContractDTO
    {
        public int? Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; }
    }
}
