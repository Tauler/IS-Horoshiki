/**
 * Created by onyushkindv on 16.11.2016.
 */
var changeSettingsServices = angular.module('changeSettingsServices', []);

changeSettingsServices.service('ChangeSettingsService', ['$http', function($http) {

    this.getList = function () {
        return $http.get(backendServerAddr+'/api/shiftPersonals/Table', {timeout: backendTimeout, headers: getToken()});
    }

    this.update = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/ShiftPersonals/Update',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

}]);