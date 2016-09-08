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

        // Пагинация
        $scope.$watch('model.paging.PageNo', function () {
            $scope.getAllPlatforms();
        });

        $scope.getAllPlatforms = function () {
            PlatformsService.getAll($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.platforms = result.Data.Data;
                    $scope.model.paging = result.Data.Paging;
                } else {
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

platformsControllers.controller('PlatformsAddController', ['$scope', '$location', 'PlatformsService', 'SubdivisionService', 'UsersService', 'DictionaryService','$routeParams',
    function ($scope, $location, PlatformsService, SubdivisionService, UsersService, DictionaryService, $routeParams) {
        $scope.model = {};

        $scope.model.platform = {
            Name: "",
            SubDivisionModel: {},
            UserModel: {},
            PlatformStatusModel: {},
            BuyProcessesModel: [],
            YandexMap: "",
            Address: "",
            TimeStart: "",
            TimeEnd: "",
            MinCheck: "",
            Id: "1"
        }

        $scope.model.error = {};
        $scope.model.error.name = false;
        $scope.checkErrorName = function () {
            if ($scope.model.platform.Name.length < 3 || $scope.model.platform.Name.length > 50) {
                $scope.model.error.name = true;
            } else {
                $scope.model.error.name = false;
            }
        }
        $scope.model.error.address = false;
        $scope.checkErrorAddress = function () {
            if ($scope.model.platform.Address.length < 3 || $scope.model.platform.Address.length > 255) {
                $scope.model.error.address = true;
            } else {
                $scope.model.error.address = false;
            }

        }
        $scope.model.error.subdivision = false;
        $scope.checkErrorSubdivisions = function () {
            if ($scope.model.subdivision == "" || $scope.model.subdivision == undefined) {
                $scope.model.error.subdivision = true;
            } else {
                $scope.model.error.subdivision = false;
            }
        }
        $scope.model.error.statusSite = false;
        $scope.checkErrorStatusSite = function () {
            if ($scope.model.statusSite == "" || $scope.model.statusSite == undefined) {
                $scope.model.error.statusSite = true;
            } else {
                $scope.model.error.statusSite = false;
            }
        }
        $scope.model.error.buyProcess = false;
        $scope.checkErrorBuyProcess = function () {
            if ($scope.model.buyProcessesValue == "" || $scope.model.buyProcessesValue == undefined) {
                $scope.model.error.buyProcess = true;
            } else {
                $scope.model.error.buyProcess = false;
            }
        }
        $scope.model.error.minCheck = false;
        $scope.checkErrorMinCheck = function () {
            console.log("checkErrorMinCheck");
            var regexpFloat = /^(?!0\d)\d*(\.\d+)?$/mg;
            if (!$scope.model.platform.MinCheck.match(regexpFloat)) {
                $scope.model.error.minCheck = true;
                console.log("true");
            } else {
                $scope.model.error.minCheck = false;
                console.log("false");
            }
        }


        $scope.getSubdivisions = function () {
            SubdivisionService.getSubdivisionsWithoutPaginate("Id", "True").success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivisions = result.Data.Data;
                } else {
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getUsers = function () {
            UsersService.getAllUsersWithoutPaginate("Id", "True").success(function (result) {
                if (result.Success == 1) {
                    $scope.model.users = result.Data.Data;
                } else {
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getStatusSites = function () {
            DictionaryService.getStatusSites().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.statusSites = result.Data;
                } else {
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getBuyProcesses = function () {
            DictionaryService.getBuyProcesses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.buyProcesses = result.Data;
                } else {
                    displayErrorMessage(result.Reason);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }


        $scope.savePlatform = function () {
            $scope.checkErrorName();
            $scope.checkErrorAddress();
            $scope.checkErrorSubdivisions();
            $scope.checkErrorStatusSite();
            $scope.checkErrorBuyProcess();
            $scope.checkErrorMinCheck();

            if ($scope.model.subdivision != null && $scope.model.subdivision != undefined) {
                $scope.model.platform.SubDivisionModel = JSON.parse($scope.model.subdivision);
            }
            if ($scope.model.user != null && $scope.model.user != undefined) {
                $scope.model.platform.UserModel = JSON.parse($scope.model.user);
            }
            if ($scope.model.statusSite != null && $scope.model.statusSite != undefined) {
                $scope.model.platform.PlatformStatusModel = JSON.parse($scope.model.statusSite);
            }

            console.log($scope.model.buyProcessesValue);
            if ($scope.model.buyProcessesValue != null && $scope.model.buyProcessesValue != undefined) {
                for (var i = 0; i < $scope.model.buyProcessesValue.length; i++) {
                    $scope.model.platform.BuyProcessesModel[i] = JSON.parse($scope.model.buyProcessesValue[i]);
                }
            }


            if (!$scope.model.error.name && !$scope.model.error.address && !$scope.model.error.subdivision && !$scope.model.error.statusSite && !$scope.model.error.buyProcess && !$scope.model.error.minCheck) {
                PlatformsService.add($scope.model.platform).success(function (result) {
                    if (result.Success == 1) {
                        $location.url("/platforms");
                    } else {
                        displayErrorMessage(result.Reason);
                    }

                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }


        }

        $scope.isEdit = function () {
           return $scope.pageId!=undefined && $scope.pageId=='platformsEditPage';
        }
        
        $scope.getPlatform = function () {
            var currentPlatform = {
                Name: "",
                SubDivisionModel: {},
                UserModel: {},
                PlatformStatusModel: {},
                BuyProcessesModel: [],
                YandexMap: "",
                Address: "",
                TimeStart: "",
                TimeEnd: "",
                MinCheck: "",
                Id: "1"
            }

            if($scope.isEdit()) {
                PlatformsService.get($routeParams.id).success(function (result) {
                    if (result.Success == 1) {
                        $scope.model.platform = result.Data;

                        if($scope.model.platform.SubDivisionModel != null && $scope.model.platform.SubDivisionModel!=''){
                            console.log($scope.model.platform.SubDivisionModel);
                            $scope.model.subdivision = JSON.stringify($scope.model.platform.SubDivisionModel);
                            console.log($scope.model.statusSite);
                        }
                        if($scope.model.platform.UserModel != null && $scope.model.platform.UserModel != ''){
                            console.log($scope.model.platform.UserModel);
                            $scope.model.user = JSON.stringify($scope.model.platform.UserModel);
                            console.log($scope.model.user)
                        }
                        if($scope.model.platform.PlatformStatusModel!=null && $scope.model.platform.PlatformStatusModel!=""){
                            console.log($scope.model.platform.PlatformStatusModel);
                            $scope.model.statusSite = JSON.stringify($scope.model.platform.PlatformStatusModel);
                            console.log($scope.model.statusSite)
                        }
                    } else {
                        displayErrorMessage(result.Reason);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })




                // console.log($scope.model.buyProcessesValue);
                // if ($scope.model.buyProcessesValue != null && $scope.model.buyProcessesValue != undefined) {
                //     for (var i = 0; i < $scope.model.buyProcessesValue.length; i++) {
                //         $scope.model.platform.BuyProcessesModel[i] = JSON.parse($scope.model.buyProcessesValue[i]);
                //     }
                // }

            }

        }


        $scope.getSubdivisions();
        $scope.getUsers();
        $scope.getStatusSites();
        $scope.getBuyProcesses();
        $scope.getPlatform();
    }
]);
