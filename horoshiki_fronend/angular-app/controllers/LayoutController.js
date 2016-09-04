/**
 * Created by onyushkindv on 19.08.2016.
 */

var layoutControllers = angular.module('layoutControllers', []);

layoutControllers.controller('HeaderController', ['$scope', '$rootScope',
    function ($scope, $rootScope) {

        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            $scope.title = current.title;
        });
    }
]);

layoutControllers.controller('LoginLayoutController', ['$scope', 'TranslationService', 'BackendService',
    function ($scope, TranslationService, BackendService) {

        // Подгружаем перевод на выбранный язык
        $scope.translate = function () {
            TranslationService.getTranslation($scope);
        };
        $scope.translate();

        // Проверка доступности бэкэнда
        BackendService.checkIsAvailable().success(function(result){
            if(result.Success == 0){
                redirectBackendError();
            }
        }).error(function(result, status){
            redirectBackendError();
        });
    }
]);

layoutControllers.controller('LayoutController', ['$scope', '$rootScope', '$location', 'TranslationService', 'AccountService', 'BackendService',
    function ($scope, $rootScope, $location, TranslationService, AccountService, BackendService) {

        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            $scope.pageId = current.pageId;
        });
        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            $scope.groupId = current.groupId;
        });
        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            $scope.subgroupId = current.subgroupId;
        });

        //Подгружаем перевод на выбранный язык
        $scope.translate = function () {
            TranslationService.getTranslation($scope);
        };
        $scope.translate();

        //Получаем текущего пользователя
        $scope.initCurrentUserModel = function () {
            $rootScope.currentUser = {};
            $rootScope.currentUserLoaded = false;
        }
        $scope.initCurrentUserModel();

        //Получаем текущего пользователя
        $scope.getCurrentUser = function () {
            AccountService.getCurrentUser().success(function (result) {
                if (result.Success == 1) {
                    $rootScope.currentUser = result.Data;
                    $rootScope.currentUserLoaded = true;
                    $rootScope.$broadcast('currentUserLoadedEvent');
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }


        // Проверка доступности бэкэнда
        BackendService.checkIsAvailable().success(function(result){
            if(result.Success == 1 && result.Data.Result == true){
                $scope.getCurrentUser();
        }else{
            redirectBackendError();
        }
        }).error(function(result, status){
            httpErrors($location.url(), status);
        });

        //Выход
        $scope.logoutButton = function () {
            sessionStorage.removeItem('accessToken');
            redirectToMainSite();
        }
    }
]);
