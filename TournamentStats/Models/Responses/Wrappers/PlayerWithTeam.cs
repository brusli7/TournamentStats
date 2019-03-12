using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models.Responses.Wrappers
{
    public class PlayerWithTeam
    {
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}