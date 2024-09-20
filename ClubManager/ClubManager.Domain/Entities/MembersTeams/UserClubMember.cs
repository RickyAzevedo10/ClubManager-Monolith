using ClubManager.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubManager.Domain.Entities.MembersTeams
{
    public class UserClubMember : BaseEntity
    {
        public long UserId { get; set; }
        public long ClubMemberId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ClubMemberId")]
        public ClubMember ClubMember { get; set; }
    }
}
