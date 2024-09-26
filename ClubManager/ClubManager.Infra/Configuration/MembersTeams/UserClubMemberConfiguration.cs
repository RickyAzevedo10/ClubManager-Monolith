using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class UserClubMemberConfiguration : IEntityTypeConfiguration<UserClubMember>
    {
        public void Configure(EntityTypeBuilder<UserClubMember> entity)
        {
            entity.HasOne(ucm => ucm.ClubMember)
                .WithOne(cm => cm.UserClubMember)
                .HasForeignKey<UserClubMember>(ucm => ucm.ClubMemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
