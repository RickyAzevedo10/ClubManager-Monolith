using Bogus;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Infrastructure.Services
{
    public class FakerService
    {
        #region Identity Faker
        public List<Institution> GenerateInstitution(int institutionCount)
        {
            int _institutionId = 1;

            var institutions = new Faker<Institution>()
                .RuleFor(i => i.Id, f => _institutionId++)
                .RuleFor(i => i.Name, f => f.Company.CompanyName())
                .RuleFor(i => i.FoundationDate, f => f.Date.Past(100))
                .RuleFor(i => i.Address, f => f.Address.FullAddress())
                .RuleFor(i => i.StadiumName, f => f.Lorem.Word())
                .RuleFor(i => i.StadiumCapacity, f => f.Random.Int(1000, 50000))
                .RuleFor(i => i.StadiumInauguration, f => f.Date.Past(50))
                .RuleFor(i => i.HaveTrainingCenter, f => f.Random.Bool())
                .RuleFor(i => i.Colors, f => f.Commerce.Color())
                .RuleFor(i => i.OfficialWebsiteUrl, f => f.Internet.Url())
                .RuleFor(i => i.SocialMediaLinks, f => f.Internet.Url())
                .Generate(institutionCount);

            return institutions;
        }

        public List<User> GenerateUsers(int userCount, Institution institution, List<UserPermissions> permissions)
        {
            var userPermissionIds = permissions.Select(p => p.Id).OrderBy(id => id).ToList();
            int currentIndex = 0;
            int _userId = 1;

            var users = new Faker<User>()
                //.RuleFor(u => u.Id, f => _userId++)  // Incrementa o ID de cada usuário
                .RuleFor(u => u.InstitutionId, institution.Id)
                .RuleFor(u => u.Email, f => $"user-{Guid.NewGuid()}@example.com")
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.PasswordHash, f => f.Random.Bytes(20))
                .RuleFor(u => u.PasswordSalt, f => f.Random.Bytes(20))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.PhoneNumberConfirmed, f => f.Random.Bool())
                .RuleFor(u => u.TwoFactorActivated, f => f.Random.Bool())
                .RuleFor(u => u.AccessFailedCount, f => f.Random.Int(0, 5))
                .RuleFor(u => u.LockoutEnd, f => f.Date.Past(1))
                .RuleFor(u => u.DateOfLastAccess, f => f.Date.Recent())
                .RuleFor(u => u.RefreshToken, f => f.Random.AlphaNumeric(16))
                .RuleFor(u => u.RefreshTokenExpire, f => f.Date.Future())
                .RuleFor(u => u.PasswordResetToken, f => f.Random.AlphaNumeric(8))
                .RuleFor(u => u.PasswordResetTokenExpire, f => f.Date.Future())
                .RuleFor(u => u.UserRoleId, f => f.Random.Int(1, 7))
                .RuleFor(u => u.UserPermissionId, f =>
                {
                    //// Atribui o ID atual e avança para o próximo da lista
                    //var id = userPermissionIds[currentIndex];
                    //currentIndex = (currentIndex + 1) % userPermissionIds.Count; // Volta ao início se atingir o fim
                    //return id;

                    // Atribui o primeiro ID da lista
                    var id = userPermissionIds[0];
                    // Remove o ID atribuído da lista
                    userPermissionIds.RemoveAt(0);
                    return id;
                })
                .Generate(userCount);

            return users;
        }

        public List<UserPermissions> GenerateUserPermissions(int count)
        {
            int _userPermissionId = 1;
            return new Faker<UserPermissions>()
                //.RuleFor(up => up.Id, f => _userPermissionId++)
                .RuleFor(up => up.Edit, f => f.Random.Bool())
                .RuleFor(up => up.Create, f => f.Random.Bool())
                .RuleFor(up => up.Delete, f => f.Random.Bool())
                .RuleFor(up => up.Consult, f => f.Random.Bool())
                .Generate(count);
        }
        #endregion

        #region Infrastructures Faker
        public List<Facility> GenerateFacilities(int facilityCount, long? categoryId = null)
        {
            int _facilityId = 1;
            var facilities = new Faker<Facility>()
                //.RuleFor(f => f.Id, f => _facilityId++)
                .RuleFor(f => f.Name, f => f.Commerce.ProductName())
                .RuleFor(f => f.FacilityCategoryId, f => categoryId ?? f.Random.Int(1, 6))
                .RuleFor(f => f.Location, f => f.Address.FullAddress())
                .RuleFor(f => f.Capacity, f => f.Random.Int(50, 5000))
                .RuleFor(f => f.Description, f => f.Lorem.Paragraph())
                .Generate(facilityCount);

            return facilities;
        }

        public List<FacilityReservation> GenerateFacilityReservations(int reservationCount, List<Facility> facilities, List<User> users)
        {
            int _facilityReservationId = 1;
            var reservations = new Faker<FacilityReservation>()
                //.RuleFor(r => r.Id, f => _facilityReservationId++)
                .RuleFor(r => r.FacilityId, f => f.PickRandom(facilities).Id)
                .RuleFor(r => r.StartTime, f => f.Date.Future())
                .RuleFor(r => r.EndTime, (f, r) => r.StartTime.AddHours(f.Random.Int(1, 4)))
                .RuleFor(r => r.EventType, f => f.Lorem.Word())
                .RuleFor(r => r.EventDescription, f => f.Lorem.Sentence())
                .RuleFor(r => r.ReservedUserId, f => f.PickRandom(users).Id)
                .Generate(reservationCount);

            return reservations;
        }

        public List<MaintenanceHistory> GenerateMaintenanceHistories(int historyCount, List<Facility> facilities, List<User> users)
        {
            int _maintenanceHistoryId = 1;
            var histories = new Faker<MaintenanceHistory>()
                //.RuleFor(h => h.Id, f => _maintenanceHistoryId++)
                .RuleFor(h => h.FacilityId, f => f.PickRandom(facilities).Id)
                .RuleFor(h => h.MaintenanceType, f => f.PickRandom("Preventiva", "Corretiva", "Urgente"))
                .RuleFor(h => h.Description, f => f.Lorem.Sentence())
                .RuleFor(h => h.MaintenanceDate, f => f.Date.Past(1))
                .RuleFor(h => h.RequestUserId, f => f.PickRandom(users).Id)
                .Generate(historyCount);

            return histories;
        }

        public List<MaintenanceRequest> GenerateMaintenanceRequests(int requestCount, List<Facility> facilities, List<User> users)
        {
            int _maintenanceRequestId = 1;
            var requests = new Faker<MaintenanceRequest>()
                //.RuleFor(r => r.Id, f => _maintenanceRequestId++)
                .RuleFor(r => r.FacilityId, f => f.PickRandom(facilities).Id)
                .RuleFor(r => r.MaintenanceType, f => f.PickRandom("Elétrica", "Hidráulica", "Estrutural"))
                .RuleFor(r => r.ProblemDescription, f => f.Lorem.Paragraph())
                .RuleFor(r => r.Priority, f => f.PickRandom("Baixa", "Média", "Alta"))
                .RuleFor(r => r.RequestDate, f => f.Date.Past(2))
                .RuleFor(r => r.RequestedUserId, f => f.PickRandom(users).Id)
                .RuleFor(r => r.Status, f => f.PickRandom("Aberto", "Em Andamento", "Concluído", "Cancelado"))
                .Generate(requestCount);

            return requests;
        }
        #endregion

        #region MembersTeams Faker
        public List<Player> GenerateFakePlayers(int count)
        {
            var faker = new Faker<Player>()
                //.RuleFor(p => p.Id, f => f.IndexFaker + 1) // IDs sequenciais
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(20, DateTime.Now.AddYears(-16)))
                .RuleFor(p => p.Nationality, f => f.Address.Country())
                .RuleFor(p => p.Position, f => f.PickRandom("Goalkeeper", "Defender", "Midfielder", "Forward"))
                .RuleFor(p => p.Height, f => f.Random.Int(160, 200))
                .RuleFor(p => p.Weight, f => f.Random.Int(60, 100))
                .RuleFor(p => p.PreferredFoot, f => f.PickRandom("Left", "Right", "Both"))
                .RuleFor(p => p.PlayerCategoryId, f => f.Random.Long(1, 5));

            return faker.Generate(count);
        }

        public List<PlayerContract> GenerateFakePlayerContracts(List<Player> players, int count)
        {
            var faker = new Faker<PlayerContract>()
                //.RuleFor(pc => pc.Id, f => f.IndexFaker + 1)
                .RuleFor(pc => pc.PlayerId, f => f.PickRandom(players).Id) // Escolhe IDs dos jogadores
                .RuleFor(pc => pc.StartDate, f => f.Date.Past(2))
                .RuleFor(pc => pc.EndDate, (f, pc) => pc.StartDate.AddYears(f.Random.Int(1, 5)))
                .RuleFor(pc => pc.Salary, f => f.Finance.Amount(20000, 500000))
                .RuleFor(pc => pc.ContractType, f => f.PickRandom("Professional", "Youth", "Amateur"));

            return faker.Generate(count);
        }

        public List<PlayerPerformanceHistory> GenerateFakePlayerPerformanceHistories(List<Player> players, int count)
        {
            var faker = new Faker<PlayerPerformanceHistory>()
                //.RuleFor(pph => pph.Id, f => f.IndexFaker + 1)
                .RuleFor(pph => pph.PlayerId, f => f.PickRandom(players).Id) // Relaciona com PlayerId
                .RuleFor(pph => pph.Season, f => $"{f.Date.Past(1).Year}/{f.Date.Past(1).Year + 1}")
                .RuleFor(pph => pph.ClubOpponent, f => f.Company.CompanyName())
                .RuleFor(pph => pph.Goals, f => f.Random.Int(0, 20))
                .RuleFor(pph => pph.Assists, f => f.Random.Int(0, 15))
                .RuleFor(pph => pph.MinutesPlayed, f => f.Random.Int(0, 90))
                .RuleFor(pph => pph.YellowCards, f => f.Random.Int(0, 5))
                .RuleFor(pph => pph.RedCards, f => f.Random.Int(0, 1));

            return faker.Generate(count);
        }

        public List<PlayerTransfer> GenerateFakePlayerTransfers(List<Player> players, int count)
        {
            var faker = new Faker<PlayerTransfer>()
                //.RuleFor(pt => pt.Id, f => f.IndexFaker + 1)
                .RuleFor(pt => pt.PlayerId, f => f.PickRandom(players).Id) // Relaciona com PlayerId
                .RuleFor(pt => pt.FromClub, f => f.Company.CompanyName())
                .RuleFor(pt => pt.ToClub, f => f.Company.CompanyName())
                .RuleFor(pt => pt.TransferDate, f => f.Date.Past(2))
                .RuleFor(pt => pt.TransferFee, f => f.Finance.Amount(10000, 10000000));

            return faker.Generate(count);
        }

        public List<ClubMember> GenerateFakeClubMembers(int count)
        {
            var faker = new Faker<ClubMember>()
                //.RuleFor(cm => cm.Id, f => f.IndexFaker + 1)
                .RuleFor(cm => cm.FirstName, f => f.Name.FirstName())
                .RuleFor(cm => cm.LastName, f => f.Name.LastName())
                .RuleFor(cm => cm.Partner, f => f.Random.Bool())
                .RuleFor(cm => cm.EducationOfficer, f => f.Random.Bool())
                .RuleFor(cm => cm.DateOfJoining, f => f.Date.Past(5))
                .RuleFor(cm => cm.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                .RuleFor(u => u.Email, f => $"user-{Guid.NewGuid()}@example.com")
                .RuleFor(cm => cm.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(cm => cm.Address, f => f.Address.FullAddress());

            return faker.Generate(count);
        }

        public List<MinorClubMember> GenerateFakeMinorClubMembers(List<ClubMember> guardians, int count)
        {
            var faker = new Faker<MinorClubMember>()
                //.RuleFor(mcm => mcm.Id, f => f.IndexFaker + 1)
                .RuleFor(mcm => mcm.FirstName, f => f.Name.FirstName())
                .RuleFor(mcm => mcm.LastName, f => f.Name.LastName())
                .RuleFor(mcm => mcm.DateOfBirth, f => f.Date.Past(12, DateTime.Now.AddYears(-5)))
                .RuleFor(mcm => mcm.DateOfJoining, f => f.Date.Past(2))
                .RuleFor(mcm => mcm.Partner, f => f.Random.Bool())
                .RuleFor(mcm => mcm.Address, f => f.Address.FullAddress())
                .RuleFor(mcm => mcm.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(mcm => mcm.Email, f => f.Internet.Email())
                .RuleFor(mcm => mcm.GuardianId, f => f.PickRandom(guardians).Id); // Relaciona com GuardianId

            return faker.Generate(count);
        }

        public List<PlayerResponsible> GenerateFakePlayerResponsibles(List<Player> players, List<ClubMember> members, int responsiblesPerPlayer)
        {
            var responsibles = new List<PlayerResponsible>();
            var responsibleId = 1;

            foreach (var player in players)
            {
                // Selecionar membros aleatórios para cada jogador
                var selectedMembers = members.OrderBy(_ => Guid.NewGuid()).Take(responsiblesPerPlayer).ToList();

                foreach (var member in selectedMembers)
                {
                    var responsible = new Faker<PlayerResponsible>()
                        //.RuleFor(r => r.Id, _ => responsibleId++)
                        .RuleFor(r => r.PlayerId, _ => player.Id)
                        .RuleFor(r => r.MemberId, _ => member.Id)
                        .RuleFor(r => r.Relationship, f => f.PickRandom("Parent", "Guardian", "Coach", "Relative"))
                        .RuleFor(r => r.IsPrimaryContact, f => f.Random.Bool())
                        .Generate();

                    responsibles.Add(responsible);
                }
            }

            return responsibles;
        }

        public List<UserClubMember> GenerateFakeUserClubMembers(List<User> users, List<ClubMember> clubMembers)
        {
            var userClubMembers = new List<UserClubMember>();
            var userClubMemberId = 1;

            // Combinar cada utilizador com um membro do clube
            var userClubPairs = users.Zip(clubMembers, (user, clubMember) => new { user, clubMember });

            foreach (var pair in userClubPairs)
            {
                var userClubMember = new Faker<UserClubMember>()
                    //.RuleFor(ucm => ucm.Id, _ => userClubMemberId++)
                    .RuleFor(ucm => ucm.UserId, _ => pair.user.Id)
                    .RuleFor(ucm => ucm.ClubMemberId, _ => pair.clubMember.Id)
                    .Generate();

                userClubMembers.Add(userClubMember);
            }

            return userClubMembers;
        }

        public List<Team> GenerateFakeTeams(Institution clubs, int count)
        {
            var teams = new List<Team>();
            var teamId = 1;

            for (int i = 0; i < count; i++)
            {
                var team = new Faker<Team>()
                    //.RuleFor(t => t.Id, _ => teamId++)
                    .RuleFor(t => t.Name, f => $"{f.Commerce.Department()} {f.Random.Word()}")
                    .RuleFor(t => t.Female, f => f.Random.Bool())
                    .RuleFor(t => t.Male, (f, t) => !t.Female) // Exclusividade entre Female e Male
                    .RuleFor(t => t.ClubId, f => f.PickRandom(clubs).Id)
                    .RuleFor(t => t.TeamCategoryId, f => f.PickRandom(1,9))
                    .Generate();

                teams.Add(team);
            }

            return teams;
        }

        public List<TeamCoach> GenerateFakeTeamCoaches(List<Team> teams, List<User> coaches, int coachesPerTeam)
        {
            var teamCoaches = new List<TeamCoach>();
            var teamCoachId = 1;

            foreach (var team in teams)
            {
                var selectedCoaches = coaches.OrderBy(_ => Guid.NewGuid()).Take(coachesPerTeam).ToList();

                foreach (var coach in selectedCoaches)
                {
                    var teamCoach = new Faker<TeamCoach>()
                        //.RuleFor(tc => tc.Id, _ => teamCoachId++)
                        .RuleFor(tc => tc.TeamId, _ => team.Id)
                        .RuleFor(tc => tc.UserId, _ => coach.Id)
                        .RuleFor(tc => tc.IsHeadCoach, f => f.Random.Bool(0.3f)) // 30% de chance de ser Head Coach
                        .Generate();

                    teamCoaches.Add(teamCoach);
                }
            }

            return teamCoaches;
        }

        public List<TeamPlayer> GenerateFakeTeamPlayers(List<Team> teams, List<Player> players, int playersPerTeam)
        {
            var teamPlayers = new List<TeamPlayer>();
            var teamPlayerId = 1;

            foreach (var team in teams)
            {
                var selectedPlayers = players.OrderBy(_ => Guid.NewGuid()).Take(playersPerTeam).ToList();

                foreach (var player in selectedPlayers)
                {
                    var teamPlayer = new Faker<TeamPlayer>()
                        //.RuleFor(tp => tp.Id, _ => teamPlayerId++)
                        .RuleFor(tp => tp.TeamId, _ => team.Id)
                        .RuleFor(tp => tp.PlayerId, _ => player.Id)
                        .Generate();

                    teamPlayers.Add(teamPlayer);
                }
            }

            return teamPlayers;
        }
        #endregion

        #region Financial Faker
        public List<Entity> GenerateFakeEntities(List<ClubMember> clubMembers, List<Player> players, int count)
        {
            var entityId = 1;
            var availablePlayers = new List<Player>(players);

            var entity = new Faker<Entity>()
                    //.RuleFor(e => e.Id, _ => entityId++)
                    .RuleFor(e => e.Internal, f => f.Random.Bool())
                    .RuleFor(e => e.External, f => f.Random.Bool())
                    .RuleFor(e => e.EntityType, f => f.PickRandom("Club", "Player", "Manager", "Sponsor"))
                    .RuleFor(e => e.EntityName, f => f.Company.CompanyName())
                    .RuleFor(e => e.ClubMemberId, f => f.PickRandom(clubMembers).Id)
                    .RuleFor(e => e.PlayerId, f =>
                    {
                        if (availablePlayers.Count == 0) return null; // Caso não haja mais jogadores disponíveis.
                        var player = f.PickRandom(availablePlayers);
                        availablePlayers.Remove(player); // Remove o jogador da lista para evitar duplicação.
                        return player.Id;
                    })
                    .Generate(count);

            return entity;
        }

        public List<Expense> GenerateFakeExpenses(List<Entity> entities, List<User> users, int count)
        {
            var expenseId = 1;
            var availableUser = new List<User>(users);

            var expense = new Faker<Expense>()
                    //.RuleFor(e => e.Id, _ => expenseId++)
                    .RuleFor(e => e.ExpenseDate, f => f.Date.Past(1))
                    .RuleFor(e => e.Amount, f => f.Finance.Amount(100, 1000))
                    .RuleFor(e => e.Destination, f => f.Company.CompanyName())
                    .RuleFor(e => e.CategoryId, f => f.PickRandom(1,15))
                    .RuleFor(e => e.Description, f => f.Lorem.Sentence())
                    .RuleFor(e => e.PaymentReference, f => f.Finance.CreditCardNumber())
                    .RuleFor(e => e.EntityId, f => f.PickRandom(entities).Id)
                    .RuleFor(e => e.ResponsibleUserId, f => {
                        if (availableUser.Count == 0) return 0;
                        var user = f.PickRandom(availableUser);
                        availableUser.Remove(user); 
                        return user.Id;
                    })
                    .Generate(count);

            return expense;
        }

        public List<Revenue> GenerateFakeRevenues(List<Entity> entities, List<User> users, int count)
        {
            var revenueId = 1;
            var availableUser = new List<User>(users);

            var revenue = new Faker<Revenue>()
                //.RuleFor(r => r.Id, _ => revenueId++)
                .RuleFor(r => r.RevenueDate, f => f.Date.Past(1))
                .RuleFor(r => r.Amount, f => f.Finance.Amount(500, 5000))
                .RuleFor(r => r.Source, f => f.Company.CompanyName())
                .RuleFor(r => r.CategoryId, f => f.PickRandom(1,15))
                .RuleFor(r => r.Description, f => f.Lorem.Sentence())
                .RuleFor(r => r.PaymentReference, f => f.Finance.CreditCardNumber())
                .RuleFor(r => r.EntityId, f => f.PickRandom(entities).Id)
                .RuleFor(e => e.ResponsibleUserId, f => {
                    if (availableUser.Count == 0) return 0;
                    var user = f.PickRandom(availableUser);
                    availableUser.Remove(user);
                    return user.Id;
                })
                .Generate(count);


            return revenue;
        }
        #endregion

        #region TrainingCompetition Faker
        public List<Match> GenerateFakeMatches(List<Team> teams, int count)
        {
            int _matchId = 1;

            var match = new Faker<Match>()
                //.RuleFor(m => m.Id, _ => _matchId++)
                .RuleFor(m => m.Date, f => f.Date.Future(1))
                .RuleFor(m => m.Opponent, f => f.PickRandom(teams).Name)
                .RuleFor(m => m.Location, f => f.Address.City())
                .RuleFor(m => m.CompetitionType, f => f.PickRandom("Friendly", "League", "Cup"))
                .RuleFor(m => m.TeamId, f => f.PickRandom(teams).Id)
                .RuleFor(m => m.IsCanceled, f => f.Random.Bool())
                .Generate(count);

            return match;
        }

        public List<MatchStatistic> GenerateFakeMatchStatistics(List<Match> matches, List<Player> players, int count)
        {
            int _matchStatisticId = 1;
            var matchStatistic = new Faker<MatchStatistic>()
                //.RuleFor(ms => ms.Id, _ => _matchStatisticId++)
                .RuleFor(ms => ms.MatchId, f => f.PickRandom(matches).Id)
                .RuleFor(ms => ms.PlayerId, f => f.PickRandom(players).Id)  
                .RuleFor(ms => ms.Goals, f => f.Random.Int(0, 3))
                .RuleFor(ms => ms.Assists, f => f.Random.Int(0, 2))
                .RuleFor(ms => ms.YellowCards, f => f.Random.Int(0, 2))
                .RuleFor(ms => ms.RedCards, f => f.Random.Int(0, 1))
                .RuleFor(ms => ms.MinutesPlayed, f => f.Random.Int(45, 90))
                .RuleFor(ms => ms.Substitutions, f => f.Random.Int(0, 3))
                .Generate(count);
 
            return matchStatistic;
        }

        public List<TrainingSession> GenerateFakeTrainingSessions(List<Team> teams, int count)
        {
            int _trainingSessionId = 1;
            var trainingSession = new Faker<TrainingSession>()
                    //.RuleFor(ts => ts.Id, _ => _trainingSessionId++)
                    .RuleFor(ts => ts.TeamId, f => f.PickRandom(teams).Id)
                    .RuleFor(ts => ts.Name, f => f.Hacker.Noun())
                    .RuleFor(ts => ts.Date, f => f.Date.Future(1))
                    .RuleFor(ts => ts.Duration, f => f.Random.Int(60, 120))
                    .RuleFor(ts => ts.Location, f => f.Address.City())
                    .RuleFor(ts => ts.Objectives, f => f.Lorem.Sentence())
                    .RuleFor(ts => ts.Description, f => f.Lorem.Paragraph())
                    .RuleFor(ts => ts.IsCanceled, f => f.Random.Bool())
                    .Generate(count);

            return trainingSession;
        }

        public List<TrainingAttendance> GenerateFakeTrainingAttendances(List<TrainingSession> sessions, List<Player> players, int count)
        {
            int _trainingAttendanceId = 1;
            var trainingAttendance = new Faker<TrainingAttendance>()
                    //.RuleFor(ta => ta.Id, _ => _trainingAttendanceId++)
                    .RuleFor(ta => ta.TrainingSessionId, f => f.PickRandom(sessions).Id)
                    .RuleFor(ta => ta.PlayerId, f => f.PickRandom(players).Id)  
                    .RuleFor(ta => ta.IsPresent, f => f.Random.Bool())
                    .RuleFor(ta => ta.AbsenceReason, f => f.Lorem.Sentence())
                    .Generate(count);
          
            return trainingAttendance;
        }
        #endregion
    }
}
