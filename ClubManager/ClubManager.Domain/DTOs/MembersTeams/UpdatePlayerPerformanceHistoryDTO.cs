namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class UpdatePlayerPerformanceHistoryDTO
    {
        public int? Id { get; set; }
        public int PlayerId { get; set; }
        public string Season { get; set; }
        public string ClubOpponent { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }  
    }
}
