/**
 * Created by onyushkindv on 19.09.2016.
 */

var reasonDismissalServices = angular.module('reasonDismissalServices', []);

reasonDismissalServices.service('ReasonDismissalService', ['$http', function($http) {

    this.getAll = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/EmployeeReasonDismissals?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

    this.get = function (id) {
        return $http.get(backendServerAddr+'/api/Platforms/'+id, {timeout: backendTimeout, headers: getToken()});
    };

    this.getAllSmall = function (sortField, asc) {
        return $http.get(backendServerAddr+'/api/EmployeeReasonDismissals/Small?sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

    this.add = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/EmployeeReasonDismissals/Add',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.edit = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/EmployeeReasonDismissals/Update',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.delete = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/EmployeeReasonDismissals/'+object.Id,
            method: 'DELETE',
            headers:  getToken()
        });
        return resp;
    };
}]);
