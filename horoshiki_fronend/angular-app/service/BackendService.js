/**
 * Created by onyushkindv on 19.08.2016.
 */

var backendServices = angular.module('backendServices', []);

backendServices.service('BackendService', ['$http', function($http) {
    this.checkIsAvailable = function(){
        return $http.get(backendServerAddr+'/web/isAvailableServer', {timeout: backendTimeout});
    }


    this.getOrders = function () {
        var accesstoken = sessionStorage.getItem('accessToken');
        var authHeaders = {};
        if (accesstoken) {
            authHeaders.Authorization = 'Bearer ' + accesstoken;
        }
        return $http.get('http://192.168.11.4:36791/api/orders', {timeout: backendTimeout, headers: authHeaders} );
    }

}]);