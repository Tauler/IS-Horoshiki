/**
 * Created by onyushkindv on 19.08.2016.
 */

var mainControllers = angular.module('mainControllers', []);

mainControllers.controller('MainViewController', ['$scope', '$location', 'BackendService',
    function ($scope, $location, BackendService) {


        BackendService.getOrders().success(function(result){
            console.log(result);
        }).error(function(result, status){

            console.log(status);
             httpErrors($location.url(), status);
        })


    }
]);
