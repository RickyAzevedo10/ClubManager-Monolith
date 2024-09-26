using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class PlayerContractConfiguration : IEntityTypeConfiguration<PlayerContract>
    {
        public void Configure(EntityTypeBuilder<PlayerContract> entity)
        {
            entity.Property(p => p.Salary)
            .HasPrecision(18, 2);
        }

    }
}
