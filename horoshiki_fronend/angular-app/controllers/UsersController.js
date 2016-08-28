/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

usersControllers.controller('UsersViewController', ['$scope', '$location', 'UsersService',
    function ($scope, $location, UsersService) {
        $scope.model = {};
        $scope.model.users = [];
        $scope.model.paging = {};
        //текущая страница по умолчанию
        $scope.model.paging.PageNo = 1;
        //количество записей на страницу
        $scope.model.clientPageSize = 10;
        //количество кнопок на строке пагинации
        $scope.model.countPageButton = 5;
        $scope.model.orderby = {}
        $scope.model.orderby.field = 'Id';
        $scope.model.orderby.asc = true;

        // Пагинация
        $scope.$watch('model.paging.PageNo', function(){
            $scope.getAllUsers();
        });

        $scope.getAllUsers = function () {
            UsersService.getAllUsers($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function(result){
                $scope.model.users = result.Data.Data;
                $scope.model.paging = result.Data.Paging;
            }).error(function(result, status){
                httpErrors($location.url(), status);
            })
        }

        $scope.changeSort = function (fieldName, asc) {
            $scope.model.orderby.field = fieldName;
            $scope.model.orderby.asc = asc;
            $scope.getAllUsers();
        }
        $scope.getAllUsers();
    }
]);

usersControllers.controller('UsersAddController', ['$scope', '$location', 'UsersService', 'DictionaryService',
    function ($scope, $location, UsersService, DictionaryService) {
        $scope.model = {};
        $scope.model.employeeStatus = {};
        $scope.model.employeeStatus.Id = "1";

        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function(result){
                if(result.Success==1) {
                    $scope.model.positions = result.Data;
                }else{
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function(result, status){
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeStatuses = function () {
            DictionaryService.getEmployeeStatuses().success(function(result){
                if(result.Success==1) {
                    $scope.model.employeeStatuses = result.Data;
                }else{
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function(result, status){
                httpErrors($location.url(), status);
            })
        }

        $scope.view = function () {
            console.log($scope.model.employeeStatus);
        }

        $scope.getPositions();
        $scope.getEmployeeStatuses();

    }


]);