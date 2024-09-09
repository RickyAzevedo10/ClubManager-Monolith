﻿using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Entities.TrainingCompetition
{
    public class Match : BaseEntity
    {
        public DateTime Date { get; set; } 
        public string Opponent { get; set; } 
        public string Location { get; set; } 
        public string CompetitionType { get; set; } 
        public int TeamId { get; set; }
        public bool IsCanceled { get; set; }

        public Team Team { get; set; }
        public ICollection<MatchStatistic> MatchStatistic { get; set; }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetOpponent(string opponent)
        {
            Opponent = opponent;
        }

        public void SetLocation(string location)
        {
            Location = location;
        }

        public void SetCompetitionType(string competitionType)
        {
            CompetitionType = competitionType;
        }

        public void SetTeamId(int teamId)
        {
            TeamId = teamId;
        }

        public void SetIsCanceled(bool isCanceled)
        {
            IsCanceled = isCanceled;
        }
    }
}