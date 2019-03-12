using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class PlayerStats
    {
        [Key]
        public int PlayerStatsId { get; set; }
        public int Scored { get; set; }
        public int Recived { get; set; }
        public bool Golkeeper { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int Fouls { get; set; }

    }
}