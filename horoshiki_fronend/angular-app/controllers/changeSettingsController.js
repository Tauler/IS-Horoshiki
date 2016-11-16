/**
 * Created by onyushkindv on 16.11.2016.
 */

var changeSettingsControllers = angular.module('changeSettingsControllers', []);

mainControllers.controller('ChangeSettingsListController', ['$scope', '$location', 'ChangeSettingsService', '$rootScope',
    function ($scope, $location, ChangeSettingsService, $rootScope) {
        $scope.model = {};
        $scope.model.changeSettings = [];
        $scope.model.isAroundClock = "false";

        $scope.isAroundClock = function () {
            return JSON.parse($scope.model.isAroundClock);
        }


        
        $scope.changeRow = function (timePart) {
            ChangeSettingsService.update(timePart).success(function (result) {
                if (result.Success == 1) {
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getChangeSettings = function () {
            ChangeSettingsService.getList().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.changeSettings = result.Data.DataRows;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $rootScope.$watch('currentUserLoaded', function(){
            if($rootScope.currentUserLoaded == true){
                $scope.getChangeSettings();
            }
        });
    }
]);
