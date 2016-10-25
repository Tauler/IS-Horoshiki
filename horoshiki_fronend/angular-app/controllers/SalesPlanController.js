/**
 * Created by onyushkindv on 24.10.2016.
 */
var salesPlanControllers = angular.module('salesPlanControllers', []);

salesPlanControllers.controller('SalesPlanIndexController', ['$scope', '$location', 'BackendService', 'SubdivisionService', 'PlatformsService', 'SalesPlanService',
    function ($scope, $location, BackendService, SubdivisionService, PlatformsService, SalesPlanService) {

        $scope.model = {};

        $scope.model.isIndex = true;

        $scope.model.salePlanTable = {};

        $scope.model.typePlanes = [];
        $scope.model.typePlanes[0] = enumTypePlan.pizza;
        $scope.model.typePlanes[1] = enumTypePlan.sushi;
        $scope.model.typePlan = angular.toJson(enumTypePlan.pizza);


        $scope.model.period = {};

        $scope.model.years = enumYears;
        $scope.model.period.year = angular.toJson(enumYears[0]);
        for(var $index in enumYears){
            if(enumYears[$index] == (new Date()).getFullYear()){
                $scope.model.period.year = angular.toJson(enumYears[$index]);
            }
        }

        $scope.model.month = enumMonth;
        $scope.model.period.month = angular.toJson(enumMonth[0]);
        for(var $index in enumMonth){
            if(enumMonth[$index].id == (new Date()).getMonth()){
                $scope.model.period.month = angular.toJson(enumMonth[$index]);
            }
        }

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


        //----------------события

        $scope.createPlan = function () {

            var dateAnalizePeriod1 = new Date($scope.model.period.year-1, JSON.parse($scope.model.period.month).id, 10);
            var dateAnalizePeriod2 = new Date($scope.model.period.year, JSON.parse($scope.model.period.month).id-1, 10);
            
            var plan = {
                "Platform": {
                    "Id": angular.toJson($scope.model.platform).Id
                },
                "SalePlanPeriod": {
                    "Year":  $scope.model.period.year,
                    "Month": JSON.parse($scope.model.period.month).id+1
                },
                "AnalizePeriod1": {
                    "Year": dateAnalizePeriod1.getFullYear(),
                    "Month": dateAnalizePeriod1.getMonth()+1
                },
                "AnalizePeriod2": {
                    "Year": dateAnalizePeriod2.getFullYear(),
                    "Month": dateAnalizePeriod2.getMonth()+1
                },
                "AverageCheck": 0,
                "PlanType": JSON.parse($scope.model.typePlan).id,
                "Id": 0
            };


            SalesPlanService.add(plan).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.salePlanTable = result.Data;
                    $scope.model.isIndex = false;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
            
        }

        //----------------

        $scope.getAllSubdivisions();
    }
]);
