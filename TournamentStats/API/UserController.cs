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
    public class UserController : APIBaseController
    {
        TournamentStatsDb _contextDb = new TournamentStatsDb();

        public ItemHttpResponse<User> GetUsers()
        {
            var users = _contextDb.Users.ToList();

            return new ItemHttpResponse<User>(users, HttpStatusCode.OK);
        }
    }
}
