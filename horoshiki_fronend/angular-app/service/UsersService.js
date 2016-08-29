/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersServices = angular.module('usersServices', []);

accountServices.service('UsersService', ['$http', function ($http) {


    this.getAllUsers = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/Accounts?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

    this.userAdd = function (user) {
        var resp = $http({
            url: backendServerAddr+'/api/Accounts/Add',
            method: 'POST',
            data: user,
            headers:  getToken(),
        });
        return resp;
    };

    this.userEdit = function (user) {
        var resp = $http({
            url: backendServerAddr+'/api/Accounts/Update',
            method: 'POST',
            data: user,
            headers:  getToken(),
        });
        return resp;
    };

    this.isExistUser = function (userName) {
        return $http.get(backendServerAddr+'api/Accounts/IsExist/'+userName, {timeout: backendTimeout, headers: getToken()});
    };

    this.getUser = function (id) {
        return $http.get(backendServerAddr+'api/Accounts/'+id, {timeout: backendTimeout, headers: getToken()});
    };


}]);