using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IMatchAppService
    {
        Task<Match?> CreateMatch(CreateMatchDTO matchBody);
        Task<Match?> DeleteMatch(long id);
        Task<Match?> GetMatch(long matchId);
        Task<List<Match>?> GetTeamMatches(long teamId);
        Task<Match?> UpdateMatch(UpdateMatchDTO matchToUpdate);
        Task<MatchStatistic?> DeleteMatchStatistic(long id);
        Task<List<MatchStatistic>?> GetMatchStatisticsFromMatchID(long matchId);
        Task<List<MatchStatistic>?> GetPlayerMatchStatistics(long playerId);
        Task<List<MatchStatistic>?> GetPlayerMatchStatisticsFromMatchId(long playerId, long matchId);
        Task<MatchStatistic?> CreateMatchStatistic(CreateMatchStatisticDTO matchStatisticBody);
        Task<MatchStatistic?> UpdateMatchStatistic(UpdateMatchStatisticDTO matchStatisticToUpdate);
    }
}
