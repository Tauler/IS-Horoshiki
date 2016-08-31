/**
 * Created by notebook on 01.09.2016.
 */

var subdivisionsControllers = angular.module('subdivisionsControllers', []);

subdivisionsControllers.controller('SubdivisionViewController', ['$scope', '$location', 'SubdivisionService',
    function ($scope, $location, SubdivisionService) {
        $scope.model = {};
        $scope.model.subdivisions = [];
        $scope.model.paging = {};
        $scope.model.paging.PageNo = 1;
        //количество записей на страницу
        $scope.model.clientPageSize = 10;
        //количество кнопок на строке пагинации
        $scope.model.countPageButton = 5;
        $scope.model.orderby = {};
        $scope.model.orderby.field = "Id";
        $scope.model.orderby.asc = true;

        $scope.$watch('model.paging.PageNo', function () {
            $scope.getDivisions();
        });
        

        $scope.getDivisions = function () {
            SubdivisionService.getAllSubdivisions($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivisions = result.Data.Data;
                    $scope.model.paging = result.Data.Paging;
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }

        $scope.changeSort = function (fieldName, asc) {
            $scope.model.orderby.field = fieldName;
            $scope.model.orderby.asc = asc;
            $scope.getDivisions();
        }

        $scope.getDivisions();
    }
]);
