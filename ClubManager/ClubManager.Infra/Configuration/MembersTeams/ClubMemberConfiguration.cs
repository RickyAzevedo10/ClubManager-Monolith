using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class ClubMemberConfiguration : IEntityTypeConfiguration<ClubMember>
    {
        public void Configure(EntityTypeBuilder<ClubMember> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(u => u.Email).IsUnique();
        }

    }
}
