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

        //Модель удаляемого объекта
        $scope.model.deletePlatformModel = {};

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
                    displayErrorMessage(result.ReasonMessage);
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

        $scope.deletePlatformModal = function (deleteObject) {
            $scope.model.deletePlatformModel = deleteObject;
            // console.log($scope.model.deletePlatformModel);
        }

        $scope.deletePlatform = function () {
            PlatformsService.delete($scope.model.deletePlatformModel).success(function (result) {
                if (result.Success == 1) {
                    $scope.getAllPlatforms();
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });

            $scope.model.deleteSubdivisionModel = {};
        }

        $scope.deleteSubdivisionClose = function () {
            $scope.model.deleteSubdivisionModel = {};
        }
    }
]);

platformsControllers.controller('PlatformsAddController', ['$scope', '$location', 'PlatformsService', 'SubdivisionService', 'UsersService', 'DictionaryService', '$routeParams',
    function ($scope, $location, PlatformsService, SubdivisionService, UsersService, DictionaryService, $routeParams) {
        $scope.model = {};
        $scope.model.buyProcessesValue = [];

        $scope.model.localTime = {
            start: '08:00',
            end: '17:00'
        }
        $scope.model.orderTime = {
            start: '08:00',
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
            if ($scope.model.localTime.start == undefined || $scope.model.localTime.start == "" || !$scope.model.localTime.start.match(regexpTime) ||
                $scope.model.localTime.end == undefined || $scope.model.localTime.end == "" || !$scope.model.localTime.end.match(regexpTime)) {
                $scope.model.error.localTime = true;
            } else {
                $scope.model.error.localTime = false;
            }
        }

        $scope.model.error.orderTime = false;
        $scope.checkOrderTime = function () {
            var regexpTime = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/mg;
            if ($scope.model.orderTime.start == undefined || $scope.model.orderTime.start == "" || !$scope.model.orderTime.start.match(regexpTime) ||
                $scope.model.orderTime.end == undefined || $scope.model.orderTime.end == "" || !$scope.model.orderTime.end.match(regexpTime)) {
                $scope.model.error.orderTime = true;
            } else {
                $scope.model.error.orderTime = false;
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
            if ($scope.model.platform.Address.length < 3 || $scope.model.platform.Address.length > 250) {
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
                $scope.model.platform.PlatformStatus.Id = "1";
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
            if ($scope.model.platform.MinCheck == undefined || $scope.model.platform.MinCheck == "" || !$scope.model.platform.MinCheck.toString().match(regexpFloat) || parseInt($scope.model.platform.MinCheck) < 1) {
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
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getUsers = function () {
            UsersService.getAllManagers("Id", "True").success(function (result) {
                if (result.Success == 1) {
                    $scope.model.users = result.Data;
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
                    displayErrorMessage(result.ReasonMessage);
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

            $scope.checkOrderTime();
            $scope.checkLocalTime();


            if (!$scope.model.error.name && !$scope.model.error.address && !$scope.model.error.subdivision && !$scope.model.error.statusSite && !$scope.model.error.buyProcess && !$scope.model.error.minCheck && !$scope.model.error.localTime && $scope.model.error.orderTime) {
                $scope.model.platform.TimeStart = $scope.model.localTime.start + ":00";
                $scope.model.platform.TimeEnd = $scope.model.localTime.end + ":00";

                $scope.model.platform.OrderTimeStart = $scope.model.orderTime.start + ":00";
                $scope.model.platform.OrderTimeEnd = $scope.model.orderTime.end + ":00";

                $scope.checkboxes.setBuyProcesses();

                if ($scope.model.platform.User == undefined || $scope.model.platform.User.Id == undefined || $scope.model.platform.User.Id == "") {
                    $scope.model.platform.User = null;
                }

                if (!$scope.isEdit()) {
                    PlatformsService.add($scope.model.platform).success(function (result) {
                        if (result.Success == 1) {
                            $location.url("/platforms");
                        } else {
                            displayErrorMessage(result.ReasonMessage);
                        }

                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    })
                } else {
                    PlatformsService.edit($scope.model.platform).success(function (result) {
                        if (result.Success == 1) {
                            $location.url("/platforms");
                        } else {
                            displayErrorMessage(result.ReasonMessage);
                        }

                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    })
                }
            }

        }

        $scope.isEdit = function () {
            return $scope.pageId != undefined && $scope.pageId == 'platformsEditPage';
        }


        $scope.checkboxes = {};
        $scope.checkboxes.getBuyProcesses = function () {
            DictionaryService.getBuyProcesses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.buyProcessesValue = result.Data;
                    for (var i = 0; i < $scope.model.buyProcessesValue.length; i++) {
                        $scope.model.buyProcessesValue[i].checked = false;
                        if ($scope.model.platform.BuyProcesses != null && $scope.model.platform.BuyProcesses != undefined) {
                            for (var j = 0; j < $scope.model.platform.BuyProcesses.length; j++) {
                                if ($scope.model.platform.BuyProcesses[j].Id == $scope.model.buyProcessesValue[j].Id) {
                                    $scope.model.buyProcessesValue[j].checked = true;
                                }
                            }
                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.checkboxes.setBuyProcesses = function () {
            if($scope.model.buyProcessesValue != null && $scope.model.buyProcessesValue != undefined)
                $scope.model.platform.BuyProcesses = [];
            for (var i = 0, j = 0; i < $scope.model.buyProcessesValue.length; i++) {
                if($scope.model.buyProcessesValue[i].checked){
                    var process = $scope.model.buyProcessesValue[i];
                    $scope.model.platform.BuyProcesses[j]={
                        Id: process.Id,
                        Value: process.Value
                    };
                    j++;
                }
            }
        }

        $scope.getPlatform = function () {
            if ($scope.isEdit()) {

                PlatformsService.get($routeParams.id).success(function (result) {
                    if (result.Success == 1) {
                        $scope.model.platform = result.Data;

                        $scope.model.platform.SubDivision.Id = $scope.model.platform.SubDivision.Id.toString();
                        if ($scope.model.platform.SubDivision.Id == "" || $scope.model.platform.SubDivision.Id == undefined) {
                            $scope.model.error.statusDisabled = true;
                        } else {
                            $scope.model.error.statusDisabled = false;
                        }

                        if($scope.model.platform.User!=undefined && $scope.model.platform.User!=null){
                            $scope.model.platform.User.Id = $scope.model.platform.User.Id.toString();
                        }
                        if($scope.model.platform.PlatformStatus!=undefined && $scope.model.platform.PlatformStatus!=null) {
                            $scope.model.platform.PlatformStatus.Id = $scope.model.platform.PlatformStatus.Id.toString();
                        }

                        if ($scope.model.platform.TimeStart != "" && $scope.model.platform.TimeStart != undefined) {
                            var startTimeArr = $scope.model.platform.TimeStart.split(':');
                            $scope.model.localTime.start = startTimeArr[0] + ":" + startTimeArr[1];
                        }
                        if ($scope.model.platform.TimeEnd != "" && $scope.model.platform.TimeEnd != undefined) {
                            var endTimeArr = $scope.model.platform.TimeEnd.split(':');
                            $scope.model.localTime.end = endTimeArr[0] + ":" + endTimeArr[1];
                        }

                        if ($scope.model.platform.OrderTimeStart != "" && $scope.model.platform.OrderTimeStart != undefined) {
                            var startTimeArr = $scope.model.platform.OrderTimeStart.split(':');
                            $scope.model.orderTime.start = startTimeArr[0] + ":" + startTimeArr[1];
                        }
                        if ($scope.model.platform.OrderTimeEnd != "" && $scope.model.platform.OrderTimeEnd != undefined) {
                            var endTimeArr = $scope.model.platform.OrderTimeEnd.split(':');
                            $scope.model.orderTime.end = endTimeArr[0] + ":" + endTimeArr[1];
                        }

                        $scope.checkboxes.getBuyProcesses();

                    } else {
                        displayErrorMessage(result.ReasonMessage);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })

            }else{
                $scope.checkboxes.getBuyProcesses();
            }
        }


        $scope.getSubdivisions();
        $scope.getUsers();
        $scope.getStatusSites();
        $scope.getPlatform();

    }
]);
