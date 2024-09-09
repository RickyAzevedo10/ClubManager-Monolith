﻿using ClubManager.Domain.Entities.TrainingCompetition;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IMatchStatisticRepository : IBaseRepository<MatchStatistic>
    {
        Task<List<MatchStatistic>?> GetMatchStatisticsFromMatchID(long matchId);
        Task<List<MatchStatistic>?> GetPlayerMatchStatistics(long playerId);
        Task<List<MatchStatistic>?> GetPlayerMatchStatisticsFromMatchId(long playerId, long matchId);
    }
}