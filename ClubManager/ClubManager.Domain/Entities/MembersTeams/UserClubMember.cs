using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Entities.MembersTeams
{
    public class UserClubMember : BaseEntity
    {
        public long UserId { get; set; }       
        public long ClubMemberId { get; set; }
        public User User { get; set; }          
        public ClubMember ClubMember { get; set; }
    }
}
