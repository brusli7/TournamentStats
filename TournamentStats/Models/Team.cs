using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamStatsId { get; set; }
        public int TournamentId { get; set; }
        public int GroupId { get; set; }
        public int KnockoutId { get; set; }
    }
}