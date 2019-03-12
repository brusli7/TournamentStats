using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentStatas.Models.Reuqests
{
    public class GroupNumberRequest
    {
        public int NumberOfGroups { get; set; }
        public int NumberOfTeamsInGroup { get; set; }
        public int TournamentId { get; set; }
    }
}