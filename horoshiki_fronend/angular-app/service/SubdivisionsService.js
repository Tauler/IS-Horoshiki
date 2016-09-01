/**
 * Created by notebook on 01.09.2016.
 */

var subdivisionsServices = angular.module('subdivisionsServices', []);

subdivisionsServices.service('SubdivisionService', ['$http', function ($http) {


    this.getAllSubdivisions = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/SubDivisions?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

    this.getSubdivision = function (id) {
        return $http.get(backendServerAddr+'api/SubDivisions/'+id, {timeout: backendTimeout, headers: getToken()});
    };

    this.subdivisionsAdd = function (subdivision) {
        var resp = $http({
            url: backendServerAddr+'/api/SubDivisions/Add',
            method: 'POST',
            data: subdivision,
            headers:  getToken(),
        });
        return resp;
    };

    this.subdivisionsEdit = function (user) {
        var resp = $http({
            url: backendServerAddr+'/api/SubDivisions/Update',
            method: 'POST',
            data: user,
            headers:  getToken(),
        });
        return resp;
    };

}]);