namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class UpdateTeamDTO
    {
        public int? Id { get; set; }
        public int TeamCategoryId { get; set; }
        public string Name { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public int ClubId { get; set; }
        public List<CreateTeamCoachDTO> TeamCoachDTO { get; set; }
        public List<long> PlayerId { get; set; }
    } 
}
