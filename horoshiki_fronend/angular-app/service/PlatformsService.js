/**
 * Created by notebook on 04.09.2016.
 */


var platformsServices = angular.module('platformsServices', []);

platformsServices.service('PlatformsService', ['$http', function($http) {

    this.getAll = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/Platforms?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

    this.get = function (id) {
        return $http.get(backendServerAddr+'api/Platforms/'+id, {timeout: backendTimeout, headers: getToken()});
    };

    this.add = function (subdivision) {
        var resp = $http({
            url: backendServerAddr+'/api/Platforms/Add',
            method: 'POST',
            data: subdivision,
            headers:  getToken()
        });
        return resp;
    };

    this.edit = function (user) {
        var resp = $http({
            url: backendServerAddr+'/api/Platforms/Update',
            method: 'POST',
            data: user,
            headers:  getToken()
        });
        return resp;
    };

    this.delete = function (subdivision) {
        var resp = $http({
            url: backendServerAddr+'/api/Platforms/'+subdivision.Id,
            method: 'DELETE',
            headers:  getToken()
        });
        return resp;
    };
}]);

