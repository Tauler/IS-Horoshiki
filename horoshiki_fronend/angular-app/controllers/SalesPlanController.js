/**
 * Created by onyushkindv on 24.10.2016.
 */
var salesPlanControllers = angular.module('salesPlanControllers', []);

salesPlanControllers.controller('SalesPlanIndexController', ['$scope', '$location', 'BackendService', 'SubdivisionService', 'PlatformsService',
    function ($scope, $location, BackendService, SubdivisionService, PlatformsService) {

        $scope.model = {};

        $scope.model.typePlanes = [];
        $scope.model.typePlanes[0] = enumTypePlan.pizza;
        $scope.model.typePlanes[1] = enumTypePlan.sushi;
        $scope.model.typePlan = angular.toJson(enumTypePlan.pizza);


        $scope.model.period = {};

        $scope.model.years = enumYears;
        $scope.model.period.year = angular.toJson(enumYears[0]);
        $scope.model.month = enumMonth;
        $scope.model.period.month = angular.toJson(enumMonth[0]);

        $scope.getAllSubdivisions = function () {
            SubdivisionService.getSubdivisionsWithoutPaginate('Id', true).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivisions = result.Data.Data;
                    if ($scope.model.subdivisions.length != 0) {
                        $scope.model.subdivision = JSON.stringify($scope.model.subdivisions[0]);
                        $scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        };

        $scope.getAllPlatformBySubdivision = function (id) {
            PlatformsService.getAllBySubdivision(id).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.platforms = result.Data;
                    if ($scope.model.platforms.length != 0) {
                        $scope.model.platform = JSON.stringify($scope.model.platforms[0]);
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        };

        $scope.changeSubdivision = function () {
            $scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
        }

        $scope.getAllSubdivisions();
    }
]);
