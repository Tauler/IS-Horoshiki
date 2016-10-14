/**
 * Created by onyushkindv on 10.10.2016.
 */

var zonesServices = angular.module('zonesServices', []);

zonesServices.service('ZonesService', ['$http', function($http) {

    this.add = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/DeliveryZones/Add',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.edit = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/DeliveryZones/Update',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };
    
}]);