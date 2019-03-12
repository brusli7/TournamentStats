using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int HomeTeamMatchStatsId { get; set; }
        public int AwayTeamMatchStatsId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TournamentId { get; set; }
    }
}