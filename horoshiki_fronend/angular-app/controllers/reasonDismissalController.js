/**
 * Created by onyushkindv on 19.09.2016.
 */
var reasonDismissalControllers = angular.module('reasonDismissalControllers', []);

reasonDismissalControllers.controller('ReasonDismissalViewControllersController', ['$scope', '$location', 'SubdivisionService',
    function ($scope, $location, SubdivisionService) {
        $scope.model = {};
    }
]);