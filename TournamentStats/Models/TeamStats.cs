using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class TeamStats
    {
        [Key]
        public int TeamStatsId { get; set; }
        public int Scored { get; set; }
        public int Recived { get; set; }
        public int Points { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
    }
}