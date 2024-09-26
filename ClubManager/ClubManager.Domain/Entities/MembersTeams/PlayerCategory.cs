namespace ClubManager.Domain.Entities.MembersTeams
{
    public class PlayerCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
