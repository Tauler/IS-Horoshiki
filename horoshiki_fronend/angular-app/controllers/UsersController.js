/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

mainControllers.controller('UsersViewController', ['$scope', '$location', 'BackendService',
    function ($scope, $location, BackendService) {
        $scope.users = 'users!!!';
    }
]);