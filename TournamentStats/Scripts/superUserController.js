angular.module("MainAppModule").controller("SuperUserController", ["$scope", "$http", "$uibModal", "TournamentData", function ($scope, $http, $uibModal, TournamentData) {


    //Data access
    //
    //
    $scope.Data = {};
    $scope.GetTournamentsForUser = function () {
        TournamentData.GetTournamentsForUser().then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Tournaments = response.data.Items;

            }
        });

    };

    $scope.SaveTournament = function (tournament) {

        TournamentData.SaveTournament(tournament).then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Tournaments = response.data.Items;

            }
        });
    };

    $scope.GetTeams = function () {

        TournamentData.GetTeams().then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Teams = response.data.Items;

            }
        });
    };

    $scope.SaveTeam = function (team) {

        TournamentData.SaveTeam(team).then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Teams = response.data.Items;

            }
        });
    };

    $scope.GetGroups = function () {

        TournamentData.GetGroups().then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Groups = response.data.Items;

            }
        });
    };

    $scope.GetGroupsWithTeams = function (object) {
        object.TournamentId = $scope.selectedTournament.TournamentId
        TournamentData.GetGroupsWithTeams(object).then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.PopulatedGroups = response.data.Items;
                $scope.showGroups = true;
            }
        });
    };

    $scope.GetPlayers = function () {

        TournamentData.GetPlayers().then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Players = response.data.Items;

            }
        });
    };

    $scope.GetUsers = function () {

        TournamentData.GetUsers().then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Users = response.data.Items;

            }
        });
    };

    $scope.SaveGroups = function (groups) {

        TournamentData.SaveGroups(groups).then(function (response) {
            if (response.data.ResponseStatusCode === 200) {
                $scope.Data.Users = response.data.Items;

            }
        });
    };

    //Switching view on admin page by button click
    //
    //
    $scope.SwitchToTournaments = function () {
        $scope.SwitchMode(0);
        $scope.GetTournamentsForUser();
    };

    $scope.SwitchToTeams = function () {
        $scope.SwitchMode(1);
        $scope.GetTeams();
    };

    $scope.SwitchToPlayers = function () {
        $scope.SwitchMode(2);
        $scope.GetPlayers();
    };
   
    $scope.SwitchMode = function (mode) {
        $scope.showTournaments = false;     
        $scope.showTeams = false;
        $scope.showPlayers = false;     

        switch (mode) {
            case 0:
                $scope.showTournaments = true;
                break;          
            case 1:
                $scope.showTeams = true;
                break;
            case 2:
                $scope.showPlayers = true;
                break;
           
        }
    };


    //Opening modals/dialog 
    //
    //



    $scope.NewTournament = function () {

        $scope.Tournament = {
            TournamentName: "",
            StartDate: null,
            EndDate: null
        };

        var modalInstance = $uibModal.open({
            templateUrl: 'TournamentForm.html',
            controller: 'ModalInstanceCtrl',
            backdrop: 'static',
            size: "lg",
            scope: $scope

        });

        modalInstance.result.then(function (value) {
            $scope.SaveTournament($scope.Tournament);

        }, function (res) {


        });
    };

    $scope.NewTeam = function () {

        $scope.Team = {
            TeamName: "",
            TournamentId: 0
        };
        $scope.GetTournaments();
        var modalInstance = $uibModal.open({
            templateUrl: 'TeamForm.html',
            controller: 'ModalInstanceCtrl',
            backdrop: 'static',
            size: "lg",
            scope: $scope,

        });

        modalInstance.result.then(function (value) {
            $scope.SaveTeam($scope.Team);

        }, function (res) {


        });
    };

    $scope.NewPlayer = function () {

        $scope.Player = {
            PlayerName: "",
            TeamId: 0,
            DOB: null
        };
        $scope.GetTeams();
        var modalInstance = $uibModal.open({
            templateUrl: 'PlayerForm.html',
            controller: 'ModalInstanceCtrl',
            backdrop: 'static',
            size: "lg",
            scope: $scope,

        });

        modalInstance.result.then(function (value) {
            $scope.SaveTeam($scope.Team);

        }, function (res) {


        });
    };
    $scope.OpenCreateGroups = function (tournament) {

        $scope.selectedTournament = tournament;
        $scope.GetGroups();
        $scope.showGroups = false;
        var modalInstance = $uibModal.open({
            templateUrl: 'CreateGroupsTemlate.html',
            controller: 'ModalInstanceCtrl',
            backdrop: 'static',
            size: "lg",
            scope: $scope,

        });

        modalInstance.result.then(function (value) {
            $scope.SaveTeam($scope.Team);

        }, function (res) {


        });
    };
}]);

angular.module('MainAppModule').controller('ModalInstanceCtrl', function ($scope, $uibModalInstance) {

    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});