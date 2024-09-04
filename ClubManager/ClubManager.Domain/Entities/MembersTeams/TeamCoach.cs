using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Entities.MembersTeams
{
    public class TeamCoach : BaseEntity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsHeadCoach { get; set; }

        public void SetTeamId(int teamId)
        {
            TeamId = teamId;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public void SetIsHeadCoach(bool isHeadCoach)
        {
            IsHeadCoach = isHeadCoach;
        }
    }
}
