namespace ClubManager.Domain.Entities.MembersTeams
{
    public class PlayerResponsible : BaseEntity
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int MemberId { get; set; }
        public ClubMember Member { get; set; }
        public string Relationship { get; set; }
        public bool IsPrimaryContact { get; set; }

        public void SetRelationship(string relationship)
        {
            Relationship = relationship;
        }

        public void SetIsPrimaryContact(bool isPrimaryContact)
        {
            IsPrimaryContact = isPrimaryContact;
        }

        public void SetMemberId(int memberId)
        {
            MemberId = memberId;
        }

        public void SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
