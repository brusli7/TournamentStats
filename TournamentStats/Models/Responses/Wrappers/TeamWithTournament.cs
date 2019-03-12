using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models.Responses.Wrappers
{
    public class TeamWithTournament
    {
        public Team Team { get; set; }
        public Tournament Tournament { get; set; }
    }
}