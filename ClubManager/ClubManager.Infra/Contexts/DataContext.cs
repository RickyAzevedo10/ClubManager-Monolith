using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Infra.Configuration.Identity;
using ClubManager.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ClubManager.Infra.Contexts
{
    //public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    public class DataContext : DbContext
    {
        private readonly FakerService _fakerService;

        public DataContext(DbContextOptions<DataContext> options, FakerService fakerService) : base(options)
        {
            _fakerService = fakerService;
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

            #region Identity Faker
            // Gerar 1 instituição
            var institutions = _fakerService.GenerateInstitution(1);
            builder.Entity<Institution>().HasData(institutions.ToArray());

            // Adicionar permissões de usuários ao banco de dados
            var userPermissions = _fakerService.GenerateUserPermissions(10);
            builder.Entity<UserPermissions>().HasData(userPermissions);

            // Adicionar os usuários ao banco de dados
            var users = _fakerService.GenerateUsers(10, institutions.First(), userPermissions);
            builder.Entity<User>().HasData(users);
            #endregion

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

            #region MembersTeams Faker

            var guardians = _fakerService.GenerateFakeClubMembers(6);
            builder.Entity<ClubMember>().HasData(guardians);

            var minorMembers = _fakerService.GenerateFakeMinorClubMembers(guardians, 4);
            builder.Entity<MinorClubMember>().HasData(minorMembers);

            var players = _fakerService.GenerateFakePlayers(10);
            builder.Entity<Player>().HasData(players);

            var playerContracts = _fakerService.GenerateFakePlayerContracts(players, 5);
            builder.Entity<PlayerContract>().HasData(playerContracts);

            var playerHistories = _fakerService.GenerateFakePlayerPerformanceHistories(players, 8);
            builder.Entity<PlayerPerformanceHistory>().HasData(playerHistories);

            var playerTransfers = _fakerService.GenerateFakePlayerTransfers(players, 3);
            builder.Entity<PlayerTransfer>().HasData(playerTransfers);

            var playerResponsibles = _fakerService.GenerateFakePlayerResponsibles(players, guardians, 2);
            builder.Entity<PlayerResponsible>().HasData(playerResponsibles);

            var userClubMembers = _fakerService.GenerateFakeUserClubMembers(users, guardians);
            builder.Entity<UserClubMember>().HasData(userClubMembers);

            var teams = _fakerService.GenerateFakeTeams(institutions, 5);
            builder.Entity<Team>().HasData(teams);

            var teamCoaches = _fakerService.GenerateFakeTeamCoaches(teams, users, 2);
            builder.Entity<TeamCoach>().HasData(teamCoaches);

            var teamPlayers = _fakerService.GenerateFakeTeamPlayers(teams, players, 5);
            builder.Entity<TeamPlayer>().HasData(teamPlayers);
            #endregion

            //Infrastructures
            builder.ApplyConfiguration(new FacilityCategoryConfiguration());

            #region Infrastructures Faker
            // Gerar Facilities
            var facilities = _fakerService.GenerateFacilities(5);
            builder.Entity<Facility>().HasData(facilities);

            // Gerar Facility Reservations
            var reservations = _fakerService.GenerateFacilityReservations(10, facilities, users);
            builder.Entity<FacilityReservation>().HasData(reservations);

            // Gerar Maintenance Histories
            var histories = _fakerService.GenerateMaintenanceHistories(8, facilities, users);
            builder.Entity<MaintenanceHistory>().HasData(histories);

            // Gerar Maintenance Requests
            var requests = _fakerService.GenerateMaintenanceRequests(12, facilities, users);
            builder.Entity<MaintenanceRequest>().HasData(requests);
            #endregion

            //Financial
            builder.ApplyConfiguration(new RevenueCategoryConfiguration());
            builder.ApplyConfiguration(new ExpenseCategoryConfiguration());
            builder.ApplyConfiguration(new ExpenseConfiguration());
            builder.ApplyConfiguration(new RevenueConfiguration());

            //#region Financial Faker
            var entities = _fakerService.GenerateFakeEntities(guardians, players, 10);
            builder.Entity<Entity>().HasData(entities);

            var expenses = _fakerService.GenerateFakeExpenses(entities, users, 10);
            builder.Entity<Expense>().HasData(expenses);

            var revenues = _fakerService.GenerateFakeRevenues(entities, users, 10);
            builder.Entity<Revenue>().HasData(revenues);
            //#endregion

            #region TrainingCompetition Faker
            var matches = _fakerService.GenerateFakeMatches(teams, 10);
            builder.Entity<Match>().HasData(matches);

            var matchStatistics = _fakerService.GenerateFakeMatchStatistics(matches, players, 30);  
            builder.Entity<MatchStatistic>().HasData(matchStatistics);

            var trainingSessions = _fakerService.GenerateFakeTrainingSessions(teams, 5);
            builder.Entity<TrainingSession>().HasData(trainingSessions);

            var trainingAttendances = _fakerService.GenerateFakeTrainingAttendances(trainingSessions, players, 50);  
            builder.Entity<TrainingAttendance>().HasData(trainingAttendances);
            #endregion
        }
    }
}
