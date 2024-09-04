namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class CreateTeamDTO
    {
        public int TeamCategoryId { get; set; }
        public string Name { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public int ClubId { get; set; }
        public List<CreateTeamCoachDTO> TeamCoachDTO { get; set; }
        public List<long> PlayerId { get; set; }
    } 

    public class CreateTeamCoachDTO
    {
        public int UserId { get; set; }
        public bool IsHeadCoach { get; set; }
    }

}
