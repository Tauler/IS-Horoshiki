/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

mainControllers.controller('UsersViewController', ['$scope', '$location', 'UsersService',
    function ($scope, $location, UsersService) {
        $scope.model = {};
        $scope.model.users = [];
        $scope.model.paging = {};
        $scope.model.clientPageSize = 10;
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
                console.log($scope.model);
            }).error(function(result, status){
                console.log(status);
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