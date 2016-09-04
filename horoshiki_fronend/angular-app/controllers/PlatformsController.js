/**
 * Created by notebook on 04.09.2016.
 */

var platformsControllers = angular.module('platformsControllers', []);

platformsControllers.controller('PlatformsViewController', ['$scope', '$location', 'PlatformsService',
    function ($scope, $location, PlatformsService) {
        $scope.model = {};
        $scope.model.platforms = [];
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


        // {
        //     Name:"Новая платформа",
        //     SubDivisionModel:{Name:"Москва","Timezone":2,"PriceTypeModel":null,"SiteHeader":"Москва","Id":2},
        //     UserModel:{"UserName":"test","Id":1},
        //     PlatformStatusModel:{"Value":"Не работает","Id":1},
        //     BuyProcessesModel:[], 
        //     YandexMap:null,
        //     Address:"выаыаыва",
        //     TimeStart:"00:00:00",
        //     TimeEnd:"08:00:00",
        //     MinCheck:342.0000,
        //     Id:4
        // }

        // Пагинация
        $scope.$watch('model.paging.PageNo', function () {
            $scope.getAllPlatforms();
        });

        $scope.getAllPlatforms = function () {
            PlatformsService.getAll($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                if(result.Success == 1){
                    $scope.model.platforms = result.Data.Data;
                    $scope.model.paging = result.Data.Paging;
                }else{
                    // displayErrorMessage($scope.translation[result.reason]);
                    displayErrorMessage(result.Reason);
                }

            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.changeSort = function (fieldName, asc) {
            $scope.model.orderby.field = fieldName;
            $scope.model.orderby.asc = asc;
            $scope.getAllPlatforms();
        }
    }
]);

platformsControllers.controller('PlatformsAddController', ['$scope', '$location', 'PlatformsService', 'SubdivisionService', 'UsersService', 'DictionaryService',
    function ($scope, $location, PlatformsService, SubdivisionService, UsersService, DictionaryService) {
        $scope.model = {};

        $scope.model.orderby = {};
        $scope.model.orderby.field = "Id";
        $scope.model.orderby.asc = "True";

        $scope.platform = {
                Name:"Новая платформа",
                SubDivisionModel:{Name:"Москва","Timezone":2,"PriceTypeModel":null,"SiteHeader":"Москва","Id":2},
                UserModel:{"UserName":"test","Id":1},
                PlatformStatusModel:{"Value":"Не работает","Id":1},
                BuyProcessesModel:[],
                YandexMap:null,
                Address:"выаыаыва",
                TimeStart:"00:00:00",
                TimeEnd:"08:00:00",
                MinCheck:342.0000,
                Id:4
        }

        $scope.getSubdivisions = function () {
            SubdivisionService.getSubdivisionsWithoutPaginate("Id", "True").success(function (result) {
                if(result.Success == 1){
                    $scope.model.subdivisions = result.Data.Data;
                }else{
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getUsers = function () {
            UsersService.getAllUsersWithoutPaginate("Id", "True").success(function (result) {
                if(result.Success == 1){
                    $scope.model.users = result.Data.Data;
                }else{
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getStatusSites = function () {
            DictionaryService.getStatusSites().success(function (result) {
                if(result.Success == 1){
                    $scope.model.statusSites = result.Data;
                }else{
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getBuyProcesses = function () {
            DictionaryService.getBuyProcesses().success(function (result) {
                if(result.Success == 1){
                    $scope.model.buyProcesses = result.Data;
                }else{
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }



        $scope.getSubdivisions();
        $scope.getUsers();
        $scope.getStatusSites();
        $scope.getBuyProcesses();
    }
]);