/**
 * Created by doninvs on 16.11.2016.
 */

var targetServices = angular.module('targetServices', []);

targetServices.service('TargetService', ['$http', function($http) {

    this.add = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/monthObjectives/Add',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.update = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/monthObjectives/Update',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };
    
}]);