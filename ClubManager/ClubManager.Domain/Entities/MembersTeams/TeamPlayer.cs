namespace ClubManager.Domain.Entities.MembersTeams
{
    public class TeamPlayer : BaseEntity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public void SetTeamId(int teamId)
        {
            TeamId = teamId;
        }

        public void SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
