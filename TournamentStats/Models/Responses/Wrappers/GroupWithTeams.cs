using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models.Responses.Wrappers
{
    public class GroupWithTeams
    {
        public Group Group { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}