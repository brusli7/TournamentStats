using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TournamentStatas.Models;

namespace TournamentStatas.DataAccess
{
    public class TournamentStatsDb : DbContext
    {
        public TournamentStatsDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TeamStats> TeamStats { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<MatchStats> MachStats { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Knockout> KnockoutStages { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamGroup> TeamGroups { get; set; }
    }
}