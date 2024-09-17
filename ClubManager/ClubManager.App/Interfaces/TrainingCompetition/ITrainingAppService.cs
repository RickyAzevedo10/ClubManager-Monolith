using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.App.Interfaces.Identity
{
    public interface ITrainingAppService
    {
        Task<TrainingSession?> DeleteTrainingSession(long id);
        Task<TrainingSession?> GetTrainingSession(long trainingSessionId);
        Task<TrainingSession?> CreateTrainingSession(CreateTrainingSessionDTO trainingSessionBody);
        Task<TrainingSession?> UpdateTrainingSession(UpdateTrainingSessionDTO trainingSessionToUpdate);
        Task<TrainingAttendance?> CreateTrainingAttendance(CreateTrainingAttendanceDTO trainingAttendanceBody);
        Task<TrainingAttendance?> DeleteTrainingAttendance(long id);
        Task<TrainingAttendance?> UpdateTrainingAttendance(UpdateTrainingAttendanceDTO trainingAttendanceToUpdate);
        Task<List<TrainingAttendance>?> GetTrainingAttendance(long trainingAttendanceId);
        Task<List<TrainingSession>?> GetTrainingSessionsByDateRange(DateTime startDate, DateTime endDate);
    }
}
