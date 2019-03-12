using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class MatchStats
    {
        [Key]
        public int MachStatsId { get; set; }
        public int TeamId { get; set; }
        public int Scored { get; set; }
        public int Recived { get; set; }
        public int Yellow { get; set; }
        public int Red { get; set; }
        public int Fouls { get; set; }
    }
}