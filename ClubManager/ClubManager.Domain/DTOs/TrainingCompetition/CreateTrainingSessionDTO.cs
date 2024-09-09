﻿namespace ClubManager.Domain.DTOs.TrainingCompetition
{
    public class CreateTrainingSessionDTO
    {
        public int TeamId { get; set; } 
        public string Name { get; set; } 
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public string Objectives { get; set; } 
        public string Description { get; set; }
        public bool IsCanceled { get; set; }
    }
}