using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Infra.Configuration.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infra.Contexts
{
    public class DataContext : DbContext
    {
        //public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Identity
        public DbSet<Institution> Institution { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }


        //MembersTeams
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerCategory> PlayerCategory { get; set; }
        public DbSet<PlayerPerformanceHistory> PlayerPerformanceHistory { get; set; }
        public DbSet<ClubMember> ClubMember { get; set; }
        public DbSet<MinorClubMember> MinorClubMember { get; set; }
        public DbSet<PlayerResponsible> PlayerResponsible { get; set; }
        public DbSet<PlayerContract> PlayerContract { get; set; }
        public DbSet<PlayerTransfer> PlayerTransfer { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamCategory> TeamCategory { get; set; }
        public DbSet<TeamPlayer> TeamPlayer { get; set; }
        public DbSet<TeamCoach> TeamCoach { get; set; }
        public DbSet<UserClubMember> UserClubMembers { get; set; }

        public DbSet<FacilityCategory> FacilityCategories { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityReservation> FacilityReservations { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());

            builder.ApplyConfiguration(new TeamCategoryConfiguration());
            builder.ApplyConfiguration(new ClubMemberConfiguration());
            builder.ApplyConfiguration(new MinorClubMemberConfiguration());
            builder.ApplyConfiguration(new PlayerCategoryConfiguration());

            builder.ApplyConfiguration(new FacilityCategoryConfiguration());
        }
    }
}
