namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class CreatePlayerContractDTO
    {
        public long PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; }
    }
}
