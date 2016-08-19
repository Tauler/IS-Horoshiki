/**
 * Created by onyushkindv on 19.08.2016.
 */

var loginControllers = angular.module('loginControllers', []);

loginControllers.controller('LoginViewController', ['$scope', '$location', 'AccountService',
    function ($scope, $location, AccountService) {

        var backUrl = $location.$$search.backUrl;

        if(backUrl == undefined || backUrl == true || backUrl == "" || backUrl.indexOf("/account/login") >= 0){
            backUrl = "/";
        }

        //Вход
        $scope.login = function () {

            AccountService.login($scope.username, $scope.password).success(function(result){
                sessionStorage.setItem('accessToken', result.access_token);
                redirect(backUrl);
            }).error(function(result, status){

                if(status==400 && result.error=="invalid_grant"){
                    displayMess("loginAlert", "");
                }else {
                    httpErrors($location.url(), status);
                }
            });

        };

    }
]);