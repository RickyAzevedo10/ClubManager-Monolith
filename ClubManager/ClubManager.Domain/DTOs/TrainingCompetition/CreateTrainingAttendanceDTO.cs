namespace ClubManager.Domain.DTOs.TrainingCompetition
{
    public class CreateTrainingAttendanceDTO
    {
        public int TrainingSessionId { get; set; }
        public int PlayerId { get; set; } 
        public bool IsPresent { get; set; } 
        public string? AbsenceReason { get; set; }
    }
}
