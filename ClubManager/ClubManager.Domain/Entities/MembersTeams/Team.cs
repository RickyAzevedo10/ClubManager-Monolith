using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Entities.MembersTeams
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public bool Female { get; set; }
        public bool Male { get; set; }
        public int ClubId { get; set; }
        public int TeamCategoryId { get; set; }
        public Institution Club { get; set; }

        public TeamCategory TeamCategories { get; set; }
        public ICollection<TeamPlayer> TeamPlayers { get; set; }
        public ICollection<TeamCoach> TeamCoaches { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
        public ICollection<Match> Matches { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetFemale(bool female)
        {
            Female = female;
        }

        public void SetMale(bool male)
        {
            Male = male;
        }

        public void SetClubId(int clubId)
        {
            ClubId = clubId;
        }

        public void SetTeamCategoryId(int teamCategoryId)
        {
            TeamCategoryId = teamCategoryId;
        }
    }
}
