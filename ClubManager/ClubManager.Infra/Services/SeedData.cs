using ClubManager.Domain.Entities;
using ClubManager.Infra.Contexts;

namespace ClubManager.Infrastructure.Services
{
    public class SeedData
    {
        public static async Task SeedAsync(DataContext context, FakerService fakeService)
        {
            var institutions = context.Institution;

            var userPermissions = fakeService.GenerateUserPermissions(33333);
            await context.UserPermissions.AddRangeAsync(userPermissions);
            await context.SaveChangesAsync();

            var users = fakeService.GenerateUsers(33333, institutions.First(), userPermissions); 
            await context.User.AddRangeAsync(users);
            await context.SaveChangesAsync();

            #region MembersTeams Faker
            var guardians = fakeService.GenerateFakeClubMembers(33333);
            await context.ClubMember.AddRangeAsync(guardians);
            await context.SaveChangesAsync();

            var minorMembers = fakeService.GenerateFakeMinorClubMembers(guardians, 4);
            await context.MinorClubMember.AddRangeAsync(minorMembers);
            await context.SaveChangesAsync();

            var players = fakeService.GenerateFakePlayers(33333);
            await context.Player.AddRangeAsync(players);
            await context.SaveChangesAsync();

            var playerContracts = fakeService.GenerateFakePlayerContracts(players, 33333);
            await context.PlayerContract.AddRangeAsync(playerContracts);
            await context.SaveChangesAsync();

            var playerHistories = fakeService.GenerateFakePlayerPerformanceHistories(players, 33333);
            await context.PlayerPerformanceHistory.AddRangeAsync(playerHistories);
            await context.SaveChangesAsync();

            var playerTransfers = fakeService.GenerateFakePlayerTransfers(players, 33333);
            await context.PlayerTransfer.AddRangeAsync(playerTransfers);
            await context.SaveChangesAsync();

            var playerResponsibles = fakeService.GenerateFakePlayerResponsibles(players, guardians, 1);
            await context.PlayerResponsible.AddRangeAsync(playerResponsibles);
            await context.SaveChangesAsync();

            var userClubMembers = fakeService.GenerateFakeUserClubMembers(users, guardians);
            await context.UserClubMembers.AddRangeAsync(userClubMembers);
            await context.SaveChangesAsync();

            var teams = fakeService.GenerateFakeTeams(institutions.First(), 10);
            await context.Team.AddRangeAsync(teams);
            await context.SaveChangesAsync();

            var teamCoaches = fakeService.GenerateFakeTeamCoaches(teams, users, 2);
            await context.TeamCoach.AddRangeAsync(teamCoaches);
            await context.SaveChangesAsync();

            var teamPlayers = fakeService.GenerateFakeTeamPlayers(teams, players, 5);
            await context.TeamPlayer.AddRangeAsync(teamPlayers);
            await context.SaveChangesAsync();
            #endregion

            #region Infrastructures Faker
            // Gerar Facilities
            var facilities = fakeService.GenerateFacilities(5);
            await context.Facilities.AddRangeAsync(facilities);
            await context.SaveChangesAsync();

            // Gerar Facility Reservations
            var reservations = fakeService.GenerateFacilityReservations(10, facilities, users);
            await context.FacilityReservations.AddRangeAsync(reservations);
            await context.SaveChangesAsync();

            // Gerar Maintenance Histories
            var histories = fakeService.GenerateMaintenanceHistories(8, facilities, users);
            await context.MaintenanceHistories.AddRangeAsync(histories);
            await context.SaveChangesAsync();

            // Gerar Maintenance Requests
            var requests = fakeService.GenerateMaintenanceRequests(12, facilities, users);
            await context.MaintenanceRequests.AddRangeAsync(requests);
            await context.SaveChangesAsync();
            #endregion

            #region Financial Faker
            var entities = fakeService.GenerateFakeEntities(guardians, players, 10);
            await context.Entities.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            var expenses = fakeService.GenerateFakeExpenses(entities, users, 10);
            await context.Expenses.AddRangeAsync(expenses);
            await context.SaveChangesAsync();

            var revenues = fakeService.GenerateFakeRevenues(entities, users, 10);
            await context.Revenues.AddRangeAsync(revenues);
            await context.SaveChangesAsync();
            #endregion

            #region TrainingCompetition Faker
            var matches = fakeService.GenerateFakeMatches(teams, 10);
            await context.Matches.AddRangeAsync(matches);
            await context.SaveChangesAsync();

            var matchStatistics = fakeService.GenerateFakeMatchStatistics(matches, players, 30);
            await context.MatchStatistics.AddRangeAsync(matchStatistics);
            await context.SaveChangesAsync();

            var trainingSessions = fakeService.GenerateFakeTrainingSessions(teams, 5);
            await context.TrainingSessions.AddRangeAsync(trainingSessions);
            await context.SaveChangesAsync();

            var trainingAttendances = fakeService.GenerateFakeTrainingAttendances(trainingSessions, players, 50);
            await context.TrainingAttendances.AddRangeAsync(trainingAttendances);
            await context.SaveChangesAsync();
            #endregion
        }
    }
}
