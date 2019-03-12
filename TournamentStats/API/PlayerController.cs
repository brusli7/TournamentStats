using MirrorcareServer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentStatas.DataAccess;
using TournamentStatas.Models;
using TournamentStatas.Models.Responses.Wrappers;

namespace TournamentStatas.API
{
    public class PlayerController : APIBaseController
    {
        private TournamentStatsDb _dbContext = new TournamentStatsDb();

        [HttpGet]
        public ItemHttpResponse<PlayerWithTeam> GetPlayers()
        {
            var teams = _dbContext.Teams.ToList();
            var result = new List<PlayerWithTeam>();
            var players = _dbContext.Players.ToList();

            foreach (var player in players)
            {
                var team = _dbContext.Teams.Where(t => t.TeamId == player.TeamId).FirstOrDefault();
                result.Add(new PlayerWithTeam { Player = player, Team = team });
            }
         
            return new ItemHttpResponse<PlayerWithTeam>(result, HttpStatusCode.OK);
        }
    }
}
