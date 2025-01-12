namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class PlayerResponseDTO
    {
        public long Id { get; set; }
        public long PlayerCategoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string PreferredFoot { get; set; }
        public List<ResponsiblePlayerResponseDTO> PlayerResponsibles { get; set; }
        public List<PlayerTransferResponseDTO> PlayerTransfers { get; set; }
        public List<PlayerContractResponseDTO> PlayerContracts { get; set; }
        public List<PlayerPerformanceHistorySimpleResponseDTO> PlayerPerformanceHistories { get; set; }
    }
    
    public class ResponsiblePlayerResponseDTO
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public string Relationship { get; set; }
        public bool IsPrimaryContact { get; set; }
    }
}
  