using AutoMapper;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Application.Mappings
{
    public class TrainingCompetitionMappingProfile : Profile
    {
        public TrainingCompetitionMappingProfile()
        {
            CreateMap<Match, MatchResponseDTO>();
            CreateMap<MatchStatistic, MatchStatisticResponseDTO>();
            CreateMap<TrainingSession, TrainingSessionResponseDTO>();
            CreateMap<TrainingAttendance, TrainingAttendanceResponseDTO>();
        }
    }
}
