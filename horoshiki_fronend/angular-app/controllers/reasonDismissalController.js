/**
 * Created by onyushkindv on 19.09.2016.
 */
var reasonDismissalControllers = angular.module('reasonDismissalControllers', []);

reasonDismissalControllers.controller('ReasonDismissalViewController', ['$scope', '$location', 'ReasonDismissalService',
    function ($scope, $location, ReasonDismissalService) {
        $scope.model = {};
        $scope.model.reasonDismissals = [];

        $scope.model.orderby = {}
        $scope.model.orderby.field = 'Name';
        $scope.model.orderby.asc = true;

        //Модель удаляемого объекта
        $scope.model.deleteModel = {};
        //Модель редактируемого объекта

        $scope.editModelDefValue = function () {
            $scope.model.editModel = {};
            $scope.model.editModel.edit = false;
            $scope.model.editModel.data = {};
            $scope.model.editModel.data.Name = '';
            $scope.model.editModel.data.Id = '1';
        }
        $scope.editModelDefValue();

        $scope.model.error = {};
        $scope.model.error.name = false;
        $scope.checkErrorName = function () {
            if ($scope.model.editModel.data.Name.length < 3 || $scope.model.editModel.data.Name.length > 50) {
                $scope.model.error.name = true;
            } else {
                $scope.model.error.name = false;
            }
        }

        $scope.editModalOpen = function (object) {
            $scope.editModelDefValue();
            $scope.model.editModel.data.Id = object.Id;
            $scope.model.editModel.data.Name = object.Name;
            $scope.model.editModel.edit = true;
        }

        $scope.deleteModalOpen = function (object) {
            $scope.model.deleteModel = object;
        }

        $scope.deleteModalClose = function () {
            $scope.model.deleteModel = {};
        }

        $scope.delete = function (object) {
            ReasonDismissalService.delete($scope.model.deleteModel)
                .success(function (result) {
                    $scope.getAllSmall();
                    $scope.deleteModalClose();
                })
                .error(function (result, status) {
                    httpErrors($location.url(), status);
                })
        }

        $scope.saveSuccess = function (result) {
            if (result.Success == 1) {
                closeModal('editModal');
                $scope.getAllSmall();
                $scope.editModelDefValue();
            } else {
                displayErrorMessage(result.ReasonMessage);
            }
        }

        $scope.editModalSave = function () {
            $scope.checkErrorName();
            if (!$scope.model.error.name) {
                if (!$scope.model.editModel.edit) {
                    ReasonDismissalService.add($scope.model.editModel.data)
                        .success(function (result) {
                            $scope.saveSuccess(result);
                        })
                        .error(function (result, status) {
                            httpErrors($location.url(), status);
                        })
                } else {
                    ReasonDismissalService.edit($scope.model.editModel.data)
                        .success(function (result) {
                            $scope.saveSuccess(result);
                        })
                        .error(function (result, status) {
                            httpErrors($location.url(), status);
                        })
                }
            }
        }


        $scope.getAllSmall = function () {
            ReasonDismissalService.getAllSmall($scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.reasonDismissals = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.changeSort = function (fieldName, asc) {
            $scope.model.orderby.field = fieldName;
            $scope.model.orderby.asc = asc;
            $scope.getAllSmall();
        }

        $scope.getAllSmall();
    }
]);