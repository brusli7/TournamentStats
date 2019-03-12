angular.module("MainAppModule").factory("TournamentData", function ($http) {
    var postconfig = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return {
        GetTournaments: function () {
            return $http.get("/api/Tournament/GetTournaments");

        },

        GetTournamentsForUser: function () {
            return $http.get("/api/Tournament/GetTournamentsForUser");

        },

        SaveTournament: function (tournament) {
            return $http.post("/api/Tournament/InsertTournament", tournament, postconfig);

        },

        GetTeams: function () {
            return $http.get("/api/Team/GetTeams");
        },

        SaveTeam: function (team) {
            return $http.post("/api/Team/InsertTeam", team, postconfig);

        },

        GetGroups: function () {
            return $http.get("/api/Team/GetGroups");

        },

        GetGroupsWithTeams: function (object) {
            return $http.post("/api/Team/GetGroupsWithTeams", object, postconfig);

        },

        GetPlayers: function () {
            return $http.get("/api/Player/GetPlayers");
        },

        GetUsers: function () {
            return $http.get("/api/User/GetUsers");
        },

        SaveGroups: function (groups) {
            return $http.post("/api/Team/SaveGroups", groups, postconfig);
        }
    };
    
   
});