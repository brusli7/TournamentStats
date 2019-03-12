namespace TournamentStatas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Knockouts",
                c => new
                    {
                        KnockoutId = c.Int(nullable: false, identity: true),
                        KnockoutName = c.String(),
                    })
                .PrimaryKey(t => t.KnockoutId);
            
            CreateTable(
                "dbo.MatchStats",
                c => new
                    {
                        MachStatsId = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        Scored = c.Int(nullable: false),
                        Recived = c.Int(nullable: false),
                        Yellow = c.Int(nullable: false),
                        Red = c.Int(nullable: false),
                        Fouls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachStatsId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HomeTeamMatchStatsId = c.Int(nullable: false),
                        AwayTeamMatchStatsId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TournamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        TeamId = c.Int(nullable: false),
                        PlayerStatsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.PlayerStats",
                c => new
                    {
                        PlayerStatsId = c.Int(nullable: false, identity: true),
                        Scored = c.Int(nullable: false),
                        Recived = c.Int(nullable: false),
                        Golkeeper = c.Boolean(nullable: false),
                        YellowCard = c.Int(nullable: false),
                        RedCard = c.Int(nullable: false),
                        Fouls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerStatsId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        TeamStatsId = c.Int(nullable: false),
                        TournamentId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        KnockoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.TeamStats",
                c => new
                    {
                        TeamStatsId = c.Int(nullable: false, identity: true),
                        Scored = c.Int(nullable: false),
                        Recived = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        YellowCard = c.Int(nullable: false),
                        RedCard = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Loses = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamStatsId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        AspNetUserId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Tournaments");
            DropTable("dbo.TeamStats");
            DropTable("dbo.Teams");
            DropTable("dbo.PlayerStats");
            DropTable("dbo.Players");
            DropTable("dbo.Matches");
            DropTable("dbo.MatchStats");
            DropTable("dbo.Knockouts");
            DropTable("dbo.Groups");
        }
    }
}
