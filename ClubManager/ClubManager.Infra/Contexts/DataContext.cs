using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Infra.Configuration.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ClubManager.Infra.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
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

        //Infrastructures
        public DbSet<FacilityCategory> FacilityCategories { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityReservation> FacilityReservations { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }

        //TrainingCompetition
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<TrainingAttendance> TrainingAttendances { get; set; }

        //Financial
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<RevenueCategory> RevenueCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Identity
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());

            //MembersTeams
            builder.ApplyConfiguration(new TeamCategoryConfiguration());
            builder.ApplyConfiguration(new TeamCoachConfiguration());
            builder.ApplyConfiguration(new ClubMemberConfiguration());
            builder.ApplyConfiguration(new UserClubMemberConfiguration());
            builder.ApplyConfiguration(new MinorClubMemberConfiguration());
            builder.ApplyConfiguration(new PlayerCategoryConfiguration());
            builder.ApplyConfiguration(new TeamPlayerConfiguration());
            builder.ApplyConfiguration(new PlayerContractConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new PlayerTransferConfiguration());

            //Infrastructures
            builder.ApplyConfiguration(new FacilityCategoryConfiguration());

            //Financial
            builder.ApplyConfiguration(new RevenueCategoryConfiguration());
            builder.ApplyConfiguration(new ExpenseCategoryConfiguration());
            builder.ApplyConfiguration(new ExpenseConfiguration());
            builder.ApplyConfiguration(new RevenueConfiguration());

        }
    }
}
