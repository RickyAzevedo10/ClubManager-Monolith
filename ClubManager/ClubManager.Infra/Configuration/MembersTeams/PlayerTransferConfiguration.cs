using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class PlayerTransferConfiguration : IEntityTypeConfiguration<PlayerTransfer>
    {
        public void Configure(EntityTypeBuilder<PlayerTransfer> entity)
        {
            entity.Property(p => p.TransferFee)
                .HasPrecision(18, 2);
        }
    }
}
