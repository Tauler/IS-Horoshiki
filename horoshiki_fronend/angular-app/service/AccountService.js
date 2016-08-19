/**
 * Created by onyushkindv on 19.08.2016.
 */

var accountServices = angular.module('accountServices', []);

accountServices.service('AccountService', ['$http', function($http) {


    this.login = function (username, password) {

        var resp = $http({
            url: "http://192.168.11.4:36791/token",
            method: "POST",
            data: $.param({ grant_type: 'password', username: username, password: password }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        });
        return resp;
    };

}]);