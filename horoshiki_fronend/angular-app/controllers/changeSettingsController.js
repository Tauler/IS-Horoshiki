/**
 * Created by onyushkindv on 16.11.2016.
 */

var changeSettingsControllers = angular.module('changeSettingsControllers', []);

mainControllers.controller('ChangeSettingsListController', ['$scope', '$location', 'ChangeSettingsService',
    function ($scope, $location, ChangeSettingsService) {
        $scope.model = {};
        $scope.model.changeSettings = [];
        $scope.model.isAroundClock = "false";

        $scope.isAroundClock = function () {
            return JSON.parse($scope.model.isAroundClock);
        }

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
        
        $scope.changeRow = function (timePart) {
            console.log("123");
            ChangeSettingsService.update(timePart).success(function (result) {
                if (result.Success == 1) {
                    console.log(result);
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }
    }
]);
