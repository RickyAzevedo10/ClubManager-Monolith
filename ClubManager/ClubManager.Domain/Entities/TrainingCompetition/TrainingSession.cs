using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Entities.TrainingCompetition
{
    public class TrainingSession : BaseEntity
    {
        public int TeamId { get; set; } 
        public string Name { get; set; } 
        public DateTime Date { get; set; } 
        public int Duration { get; set; } 
        public string Location { get; set; } 
        public string Objectives { get; set; } 
        public string Description { get; set; } 
        public bool IsCanceled { get; set; }

        public ICollection<TrainingAttendance> TrainingAttendances { get; set; }
        public Team Team { get; set; }

        public void SetTeamId(int teamId)
        {
            TeamId = teamId;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        public void SetLocation(string location)
        {
            Location = location;
        }

        public void SetObjectives(string objectives)
        {
            Objectives = objectives;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetIsCanceled(bool isCanceled)
        {
            IsCanceled = isCanceled;
        }

    }
}
