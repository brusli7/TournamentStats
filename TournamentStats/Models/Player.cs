using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public DateTime DOB { get; set; }
        public int TeamId { get; set; }
        public int PlayerStatsId { get; set; }
    }
}