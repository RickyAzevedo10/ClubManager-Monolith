using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface ITrainingService
    {
        Task<TrainingSession?> DeleteTrainingSession(long id);
        Task<TrainingSession?> CreateTrainingSession(CreateTrainingSessionDTO trainingSessionBody);
        Task<TrainingSession?> UpdateTrainingSession(UpdateTrainingSessionDTO trainingSessionToUpdate, TrainingSession trainingSession);
        Task<TrainingAttendance?> CreateTrainingAttendance(CreateTrainingAttendanceDTO trainingAttendanceBody);
        Task<TrainingAttendance?> DeleteTrainingAttendance(long id);
        Task<TrainingAttendance?> UpdateTrainingAttendance(UpdateTrainingAttendanceDTO trainingAttendanceToUpdate, TrainingAttendance trainingAttendance);
    }
}