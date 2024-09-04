using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class MinorClubMemberConfiguration : IEntityTypeConfiguration<MinorClubMember>
    {
        public void Configure(EntityTypeBuilder<MinorClubMember> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(u => u.Email).IsUnique();
        }

    }
}
