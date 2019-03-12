using Microsoft.AspNet.Identity;
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
    public class APIBaseController : ApiController
    {

        protected TournamentStatsDb _dbContext = new TournamentStatsDb();

        private User _user = null;
        public User LoggedInUser
        {
            get
            {
                if (_user == null)
                {
                    var userID = User.Identity.GetUserId();
                    _user = _dbContext.Users.Where(u => u.AspNetUserId == userID).FirstOrDefault();
                }
                return _user;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
