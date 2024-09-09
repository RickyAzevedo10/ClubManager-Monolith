using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Entities.TrainingCompetition
{
    public class TrainingAttendance : BaseEntity
    {
        public int TrainingSessionId { get; set; } 
        public int PlayerId { get; set; } 
        public bool IsPresent { get; set; } 
        public string AbsenceReason { get; set; }

        public TrainingSession TrainingSessions { get; set; }
        public Player Player { get; set; }

        public void SetTrainingSessionId(int trainingSessionId)
        {
            TrainingSessionId = trainingSessionId;
        }

        public void SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }

        public void SetIsPresent(bool isPresent)
        {
            IsPresent = isPresent;
        }

        public void SetAbsenceReason(string absenceReason)
        {
            AbsenceReason = absenceReason;
        }

    }
}
