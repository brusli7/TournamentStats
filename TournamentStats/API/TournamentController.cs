using MirrorcareServer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentStatas.DataAccess;
using TournamentStatas.Models;

namespace TournamentStatas.API
{
    public class TournamentController : APIBaseController
    {
        
        public ItemHttpResponse<Tournament> GetTournaments()
        {
            var result = _dbContext.Tournaments.ToList();
            return new ItemHttpResponse<Tournament>( result, HttpStatusCode.OK);
        }

        [HttpGet]
        public ItemHttpResponse<Tournament> GetTournamentsForUser()
        {
            
            var result = _dbContext.Tournaments.Where(t => t.UserId == LoggedInUser.UserId).ToList();
            return new ItemHttpResponse<Tournament>(result, HttpStatusCode.OK);
        }

        [HttpPost]
        public ItemHttpResponse<Tournament> InsertTournament(Tournament tournament)
        {

            if (ModelState.IsValid)
            {
                tournament.UserId = LoggedInUser.UserId;
                var insertedTournament = _dbContext.Tournaments.Add(tournament);
                _dbContext.SaveChanges();
                var result = _dbContext.Tournaments.ToList();
                return new ItemHttpResponse<Tournament>(result, HttpStatusCode.OK);
            }
           
            return new ItemHttpResponse<Tournament>(null, HttpStatusCode.BadRequest);
        }
    }
}
