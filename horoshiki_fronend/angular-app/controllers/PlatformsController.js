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
        $scope.model.buyProcessesValue = [];
        
        $scope.model.localTime = {
            start : '08:00',
            end: '17:00'
        }

        $scope.model.platform = {
            Name: "",
            SubDivision: {},
            User: {},
            PlatformStatus: {Id: "1"},
            BuyProcesses: [],
            YandexMap: "",
            Address: "",
            TimeStart: "",
            TimeEnd: "",
            MinCheck: "",
            Id: "1"
        }

        $scope.model.error = {};
        $scope.model.error.localTime = false;
        $scope.checkLocalTime = function () {
            var regexpTime = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/mg;
            if($scope.model.localTime.start==undefined || $scope.model.localTime.start=="" || !$scope.model.localTime.start.match(regexpTime) ||
                $scope.model.localTime.end==undefined || $scope.model.localTime.end=="" || !$scope.model.localTime.end.match(regexpTime)){
                $scope.model.error.localTime = true;
            }else{
                $scope.model.error.localTime = false;
            }
        }

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
        $scope.model.error.statusDisabled = true;
        $scope.checkErrorSubdivisions = function () {
            if ($scope.model.platform.SubDivision.Id == "" || $scope.model.platform.SubDivision.Id == undefined) {
                $scope.model.error.subdivision = true;
                $scope.model.error.statusDisabled = true;
                $scope.model.platform.PlatformStatus.Id ="1";
            } else {
                $scope.model.error.subdivision = false;
                $scope.model.error.statusDisabled = false;
            }
        }
        $scope.model.error.statusSite = false;
        $scope.checkErrorStatusSite = function () {
            if ($scope.model.platform.PlatformStatus.Id == "" || $scope.model.platform.PlatformStatus.Id == undefined) {
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
            var regexpFloat = /^(?!0\d)\d*(\.\d+)?$/mg;
            if ($scope.model.platform.MinCheck==undefined || $scope.model.platform.MinCheck=="" || !$scope.model.platform.MinCheck.toString().match(regexpFloat) ||  parseInt($scope.model.platform.MinCheck) < 1) {
                $scope.model.error.minCheck = true;
            } else {
                $scope.model.error.minCheck = false;
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


            if (!$scope.model.error.name && !$scope.model.error.address && !$scope.model.error.subdivision && !$scope.model.error.statusSite && !$scope.model.error.buyProcess && !$scope.model.error.minCheck) {
                $scope.model.platform.TimeStart = $scope.model.localTime.start+":00";
                $scope.model.platform.TimeEnd = $scope.model.localTime.end+":00";

                if ($scope.model.buyProcessesValue != null && $scope.model.buyProcessesValue != undefined) {
                    for (var i = 0; i < $scope.model.buyProcessesValue.length; i++) {
                        $scope.model.platform.BuyProcesses[i] = JSON.parse($scope.model.buyProcessesValue[i]);
                    }
                }

                if(!$scope.isEdit()) {
                    PlatformsService.add($scope.model.platform).success(function (result) {
                        if (result.Success == 1) {
                            $location.url("/platforms");
                        } else {
                            displayErrorMessage(result.Reason);
                        }

                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    })
                }else{
                    PlatformsService.edit($scope.model.platform).success(function (result) {
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

        }

        $scope.isEdit = function () {
           return $scope.pageId!=undefined && $scope.pageId=='platformsEditPage';
        }

        $scope.getPlatform = function () {
            if($scope.isEdit()) {
                PlatformsService.get($routeParams.id).success(function (result) {
                    if (result.Success == 1) {
                        $scope.model.platform = result.Data;

                        $scope.model.platform.SubDivision.Id = $scope.model.platform.SubDivision.Id.toString();
                        $scope.model.platform.User.Id = $scope.model.platform.User.Id.toString();
                        $scope.model.platform.PlatformStatus.Id = $scope.model.platform.PlatformStatus.Id.toString();

                        if($scope.model.platform.TimeStart!="" && $scope.model.platform.TimeStart!=undefined) {
                            var startTimeArr = $scope.model.platform.TimeStart.split(':');
                            $scope.model.localTime.start = startTimeArr[0]+":"+startTimeArr[1];
                        }
                        if($scope.model.platform.TimeEnd!="" && $scope.model.platform.TimeEnd!=undefined) {
                            var endTimeArr = $scope.model.platform.TimeEnd.split(':');
                            $scope.model.localTime.end = endTimeArr[0]+":"+endTimeArr[1];
                        }

                        if ($scope.model.platform.BuyProcesses != null && $scope.model.platform.BuyProcesses != undefined) {
                                for (var i = 0; i < $scope.model.platform.BuyProcesses.length; i++) {
                                    $scope.model.buyProcessesValue[i] = JSON.stringify($scope.model.platform.BuyProcesses[i]);
                                }
                            }
                    } else {
                        displayErrorMessage(result.Reason);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })

            }

        }


        $scope.getSubdivisions();
        $scope.getUsers();
        $scope.getStatusSites();
        $scope.getBuyProcesses();
        $scope.getPlatform();
    }
]);
