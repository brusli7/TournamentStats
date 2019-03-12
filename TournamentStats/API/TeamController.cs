using MirrorcareServer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentStatas.DataAccess;
using TournamentStatas.Models;
using TournamentStatas.Models.Responses.Wrappers;
using TournamentStatas.Models.Reuqests;

namespace TournamentStatas.API
{
    public class TeamController : APIBaseController
    {
        private TournamentStatsDb _dbContext = new TournamentStatsDb();

        [HttpGet]
        public ItemHttpResponse<TeamWithTournament> GetTeams()
        {
            var teams = _dbContext.Teams.ToList();
            var result = new List<TeamWithTournament>();
            foreach (var team in teams)
            {
                var tournament = _dbContext.Tournaments.Where(t => t.TournamentId == team.TournamentId).FirstOrDefault();
                result.Add(new TeamWithTournament { Team = team, Tournament = tournament });
            }
            
            
            return new ItemHttpResponse<TeamWithTournament>(result, HttpStatusCode.OK);
        }

        [HttpPost]
        public ItemHttpResponse<TeamWithTournament> InsertTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var teamStats = new TeamStats { Draws = 0, Loses = 0, Points = 0, Recived = 0, RedCard = 0, Scored = 0, Wins = 0, YellowCard = 0 };
                var newTeamStats = _dbContext.TeamStats.Add(teamStats);
                _dbContext.SaveChanges();
                team.TeamStatsId = newTeamStats.TeamStatsId;
                var insertedTeam = _dbContext.Teams.Add(team);
                _dbContext.SaveChanges();
                var teams = _dbContext.Teams.ToList();
                var result = new List<TeamWithTournament>();
                foreach (var teamFromDb in teams)
                {
                    var tournament = _dbContext.Tournaments.Where(t => t.TournamentId == teamFromDb.TournamentId).FirstOrDefault();
                    result.Add(new TeamWithTournament { Team = teamFromDb, Tournament = tournament });
                }


                return new ItemHttpResponse<TeamWithTournament>(result, HttpStatusCode.OK);
            }
           


            return new ItemHttpResponse<TeamWithTournament>(null, HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ItemHttpResponse<TeamWithTournament> SaveGroups(List<GroupWithTeams> groupsWithTeams)
        {

            foreach (var group in groupsWithTeams)
            {
                foreach (var team in group.Teams)
                {
                    team.GroupId = group.Group.GroupId;
                    _dbContext.Entry(team).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }
                       
            var teams = _dbContext.Teams.ToList();
            var result = new List<TeamWithTournament>();
            

            return new ItemHttpResponse<TeamWithTournament>(result, HttpStatusCode.OK);              
        }

        [HttpGet]
        public ItemHttpResponse<Group> GetGroups()
        {

            var result = _dbContext.Groups.ToList();
           

            return new ItemHttpResponse<Group>(result, HttpStatusCode.OK);
        }

        [HttpPost]
        public ItemHttpResponse<GroupWithTeams> GetGroupsWithTeams(GroupNumberRequest groupNumberRequest)
        {
            
            if (groupNumberRequest == null || groupNumberRequest.NumberOfGroups <= 0 || groupNumberRequest.NumberOfTeamsInGroup <= 0 || groupNumberRequest.TournamentId <= 0)
            {
                return new ItemHttpResponse<GroupWithTeams>(null, HttpStatusCode.BadRequest);
            }

            var tournament = _dbContext.Tournaments.Where(t => t.TournamentId == groupNumberRequest.TournamentId).FirstOrDefault();

            if(tournament == null)
            {
                return new ItemHttpResponse<GroupWithTeams>(null, HttpStatusCode.BadRequest);
            }

            var result = new List<GroupWithTeams>();
            var groups = _dbContext.Groups.Take(groupNumberRequest.NumberOfGroups).ToList();
            var teams = _dbContext.Teams.Where(t => t.TournamentId == tournament.TournamentId);
            var shuffledTeams = ShuffleTeams(teams.ToList());

            var lists = new List<List<Team>>();

            foreach (var group in groups)
            {
                var teamsInGroup = AddTeamsToGroup(shuffledTeams, groupNumberRequest.NumberOfTeamsInGroup, group);
                result.Add(new GroupWithTeams { Group = group, Teams = teamsInGroup } );
                

            }

            if (shuffledTeams.Any())
            {
                result.Add(new GroupWithTeams { Group = new Group { GroupName = "Not asigned teams"}, Teams = shuffledTeams });
            }

            return new ItemHttpResponse<GroupWithTeams>(result, HttpStatusCode.OK);
        }



        private List<Team> ShuffleTeams(List<Team> list)
        {
                       
            var randomizedList = new List<Team>();
            var rnd = new Random();
            while (list.Count != 0)
            {
                var index = rnd.Next(0, list.Count);
                randomizedList.Add(list[index]);
                list.RemoveAt(index);
            }
            return randomizedList;
        }

        private List<Team> AddTeamsToGroup(List<Team> teams, int numerOfTeamsInGroup, Group group)
        {
            var result = new List<Team>();

            for (int i = 0; i < numerOfTeamsInGroup; i++)
            {
                if (teams.Any())
                {
                    result.Add(teams[0]);
                    teams.RemoveAt(0);
                }
                
            }
            return result.OrderBy(t => t.TeamName).ToList();
        }

        
    }
}
