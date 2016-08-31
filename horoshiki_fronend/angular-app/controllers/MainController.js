/**
 * Created by onyushkindv on 19.08.2016.
 */

var mainControllers = angular.module('mainControllers', []);

mainControllers.controller('MainViewController', ['$scope', '$location', 'BackendService',
    function ($scope, $location, BackendService) {

        
        
        
        


    //     $scope.obj={};
    //     // BackendService.getOrders().success(function(result){
    //     //     console.log(result);
    //     // }).error(function(result, status){
    //     //
    //     //     console.log(status);
    //     //      httpErrors($location.url(), status);
    //     // })
    //
    //     $scope.geoObj = {
    //         geometry: {
    //             type: 'Polygon',
    //             coordinates: []
    //         }
    //     }
    //
    //
    //
    //     $scope.getPoint = function (target) {
    //         $scope.obj = target;
    //     }
    //
    //     $scope.viewPoint = function () {
    //         console.log($scope.obj.geometry.getCoordinates());
    //     }
    //
    }
]);
