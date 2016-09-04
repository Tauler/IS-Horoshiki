/**
 * Created by notebook on 04.09.2016.
 */


var platformsServices = angular.module('platformsServices', []);

platformsServices.service('PlatformsService', ['$http', function($http) {

    this.getAll = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/Platforms?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };
    
}]);

