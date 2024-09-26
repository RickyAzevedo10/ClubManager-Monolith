﻿namespace ClubManager.Domain.DTOs.TrainingCompetition
{
    public class MatchStatisticResponseDTO
    {
        public long Id { get; set; }
        public long MatchId { get; set; } 
        public long PlayerId { get; set; } 
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; } 
        public int RedCards { get; set; }
        public int MinutesPlayed { get; set; } 
        public int Substitutions { get; set; }
    }
}