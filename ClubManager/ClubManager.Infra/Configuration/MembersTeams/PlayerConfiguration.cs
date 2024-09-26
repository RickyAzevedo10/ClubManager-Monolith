using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity
             .HasOne(p => p.Entity)
             .WithOne(e => e.Player)
             .HasForeignKey<Entity>(e => e.PlayerId)
             .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
