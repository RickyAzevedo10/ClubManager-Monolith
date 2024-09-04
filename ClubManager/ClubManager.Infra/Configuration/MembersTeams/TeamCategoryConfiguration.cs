using ClubManager.Domain.Entities.MembersTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubManager.Infra.Configuration.Identity
{
    internal class TeamCategoryConfiguration : IEntityTypeConfiguration<TeamCategory>
    {
        public void Configure(EntityTypeBuilder<TeamCategory> entity)
        {
            entity.HasKey(e => e.Id);
            SeedData(entity);
        }
        public void SeedData(EntityTypeBuilder<TeamCategory> entity)
        {
            // Verificar se já existem dados
            if (!entity.Metadata.GetSeedData().Any())
            {
                entity.HasData(
                    new TeamCategory { Id = 1, Name = "Pré-Petizes" },
                    new TeamCategory { Id = 2, Name = "Petizes" },
                    new TeamCategory { Id = 3, Name = "Traquinas" },
                    new TeamCategory { Id = 4, Name = "Benjamins" },
                    new TeamCategory { Id = 5, Name = "Infantis" },
                    new TeamCategory { Id = 6, Name = "Iniciados" },
                    new TeamCategory { Id = 7, Name = "Juvenis" },
                    new TeamCategory { Id = 8, Name = "Juniores" },
                    new TeamCategory { Id = 9, Name = "Seniores" }
                );
            }
        }
    }
}
