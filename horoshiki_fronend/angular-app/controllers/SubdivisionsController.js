/**
 * Created by notebook on 01.09.2016.
 */

var subdivisionsControllers = angular.module('subdivisionsControllers', []);

subdivisionsControllers.controller('SubdivisionListController', ['$scope', '$location', 'SubdivisionService',
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
        //Модель удаляемого объекта
        $scope.model.deletSubdivisionModel = {};

        $scope.$watch('model.paging.PageNo', function () {
            $scope.getDivisions();
        });


        $scope.getDivisions = function () {
            SubdivisionService.getAllSubdivisions($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivisions = result.Data.Data;
                    $scope.model.paging = result.Data.Paging;
                } else {
                    displayErrorMessage(result.ReasonMessage);
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

        $scope.deleteSubdivisionModal = function (deleteObject) {
            $scope.model.deleteSubdivisionModel = deleteObject;
        }

        $scope.deleteSubdivision = function () {
            SubdivisionService.subdivisionsDelete($scope.model.deleteSubdivisionModel).success(function (result) {
                if (result.Success == 1) {
                    $scope.getDivisions();
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

subdivisionsControllers.controller('SubdivisionAddController', ['$scope', '$location', 'SubdivisionService', 'DictionaryService','$routeParams',
    function ($scope, $location, SubdivisionService, DictionaryService, $routeParams) {
        $scope.model = {};

        $scope.model.subdivision = {
            Name: "",
            Timezone: "",
            PriceTypeModel: "",
            SiteHeader: "",
            Id: 1
        }

        $scope.model.priceTypeModel = "";


        //errors init
        $scope.model.error = {};

        $scope.model.error.name = false;
        $scope.checkErrorName = function () {
            if ($scope.model.subdivision.Name.length < 3 || $scope.model.subdivision.Name.length > 50) {
                $scope.model.error.name = true;
            } else {
                $scope.model.error.name = false;
            }
        }
        $scope.model.error.timezone = false;
        $scope.checkErrorTimezone = function () {
            var timezone = /^[0-9-]{1,3}$/;
            if (!$scope.model.subdivision.Timezone.toString().match(timezone) ||  parseInt($scope.model.subdivision.Timezone) < -12 ||  parseInt($scope.model.subdivision.Timezone) > 12) {
                $scope.model.error.timezone = true;
            } else {
                $scope.model.error.timezone = false;
            }
        }
        $scope.model.error.priceType = false;
        $scope.checkErrorPriceType = function () {
            if ($scope.model.priceTypeModel == "" || $scope.model.priceTypeModel == undefined) {
                $scope.model.error.priceType = true;
            } else {
                $scope.model.error.priceType = false;
            }
        }
        $scope.model.error.siteHeader = false;
        $scope.checkErrorSiteHeader = function () {
            if ($scope.model.subdivision.SiteHeader.length > 50) {
                $scope.model.error.siteHeader = true;
            } else {
                $scope.model.error.siteHeader = false;
            }
        }

        $scope.getPriceType = function () {
            DictionaryService.getPriceType().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.priceType = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }

        $scope.getSubdivision = function () {
            SubdivisionService.getSubdivision($routeParams.subdivisionId).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivision = result.Data;
                    $scope.model.priceTypeModel = JSON.stringify($scope.model.subdivision.PriceType);
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }

        $scope.isEdit = function () {
            return $scope.pageId!=undefined && $scope.pageId=='subdivisionEditPage';
        }

        $scope.saveSubdivision = function () {
            $scope.checkErrorName();
            $scope.checkErrorTimezone();
            $scope.checkErrorPriceType();
            $scope.checkErrorSiteHeader();

            if(!$scope.model.error.name && !$scope.model.error.timezone && !$scope.model.error.priceType && !$scope.model.error.siteHeader){

                if ($scope.model.priceTypeModel != "" && $scope.model.priceTypeModel != undefined) {
                    $scope.model.subdivision.PriceType = JSON.parse($scope.model.priceTypeModel);
                }

                if(!$scope.isEdit()) {
                    SubdivisionService.subdivisionsAdd($scope.model.subdivision).success(function (result) {
                        if (result.Success == 1) {
                            $location.url("/subdivisions");
                        } else {
                            displayErrorMessage(result.ReasonMessage);
                        }
                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    });
                }else{
                    SubdivisionService.subdivisionsEdit($scope.model.subdivision).success(function (result) {
                        if (result.Success == 1) {
                            $location.url("/subdivisions");
                        } else {
                            displayErrorMessage(result.ReasonMessage);
                        }
                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    });
                }
            }
        }

        $scope.getPriceType();

        if($scope.isEdit()){
            $scope.getSubdivision()
        }
    }
]);