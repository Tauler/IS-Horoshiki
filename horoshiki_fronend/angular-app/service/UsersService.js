/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersServices = angular.module('usersServices', []);

accountServices.service('UsersService', ['$http', function ($http) {


    this.getAllUsers = function (currentPage, pageSize, sortField, asc) {
        return $http.get(backendServerAddr+'/api/Accounts?pageNo='+currentPage+'&pageSize='+pageSize+'&sortField='+sortField+'&isAscending='+asc, {timeout: backendTimeout, headers: getToken()});
    };

}]);