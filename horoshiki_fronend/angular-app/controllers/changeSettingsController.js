/**
 * Created by onyushkindv on 16.11.2016.
 */

var changeSettingsControllers = angular.module('changeSettingsControllers', []);

mainControllers.controller('ChangeSettingsListController', ['$scope', '$location', 'ChangeSettingsService',
    function ($scope, $location, ChangeSettingsService) {
        $scope.model = {};
        $scope.model.changeSettings = [];
        $scope.model.time="05:55:00";

        ChangeSettingsService.getList().success(function (result) {
            if (result.Success == 1) {
                $scope.model.changeSettings = result.Data.DataRows;

                console.log($scope.model.changeSettings );
            } else {
                displayErrorMessage(result.ReasonMessage);
            }
        }).error(function (result, status) {
            httpErrors($location.url(), status);
        })
    }
]);
