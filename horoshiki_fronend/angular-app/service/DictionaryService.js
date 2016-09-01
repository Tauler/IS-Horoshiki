/**
 * Created by onyushkindv on 26.08.2016.
 */

var dictionaryServices = angular.module('dictionaryServices', []);

dictionaryServices.service('DictionaryService', ['$http', function($http) {

    this.getEmployeeStatuses = function () {
        return $http.get(backendServerAddr+'/api/EmployeeStatuses', {timeout: backendTimeout, headers: getToken()});
    }

    this.getPositions = function () {
        return $http.get(backendServerAddr+'/api/Positions', {timeout: backendTimeout, headers: getToken()});
    }

    this.getPriceType = function () {
        return $http.get(backendServerAddr+'/api/PriceTypes', {timeout: backendTimeout, headers: getToken()});
    }


}]);

