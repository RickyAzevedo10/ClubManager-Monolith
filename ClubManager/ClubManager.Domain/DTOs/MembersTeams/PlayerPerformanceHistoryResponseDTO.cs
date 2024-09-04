using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class PlayerPerformanceHistoryResponseDTO
    {
        public string Season { get; set; }
        public int NumberOfGoals { get; set; }
        public int NumberOfAssists { get; set; }
        public int NumberOfMatchesPlayed { get; set; }
        public int NumberOfMinutesPlayed { get; set; }
        public int NumberOfYellowCards { get; set; }
        public int NumberOfRedCards { get; set; }
    }
}
