using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class Knockout
    {
        [Key]
        public int KnockoutId { get; set; }
        public string KnockoutName { get; set; }
    }
}