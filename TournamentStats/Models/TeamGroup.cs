using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models
{
    public class TeamGroup
    {
        [Key]
        public int TeamGroupId { get; set; }
        public int TeamId { get; set; }
        public int GroupId { get; set; }
    }
}