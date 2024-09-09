using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Entities.TrainingCompetition
{
    public class MatchStatistic : BaseEntity
    {
        public int MatchId { get; set; } 
        public int PlayerId { get; set; } 
        public int Goals { get; set; } 
        public int Assists { get; set; } 
        public int YellowCards { get; set; } 
        public int RedCards { get; set; } 
        public int MinutesPlayed { get; set; } 
        public int Substitutions { get; set; }

        public Match Match { get; set; }
        public Player Player { get; set; }

        public void SetMatchId(int matchId)
        {
            MatchId = matchId;
        }

        public void SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }

        public void SetGoals(int goals)
        {
            Goals = goals;
        }

        public void SetAssists(int assists)
        {
            Assists = assists;
        }

        public void SetYellowCards(int yellowCards)
        {
            YellowCards = yellowCards;
        }

        public void SetRedCards(int redCards)
        {
            RedCards = redCards;
        }

        public void SetMinutesPlayed(int minutesPlayed)
        {
            MinutesPlayed = minutesPlayed;
        }

        public void SetSubstitutions(int substitutions)
        {
            Substitutions = substitutions;
        }

    }
}
