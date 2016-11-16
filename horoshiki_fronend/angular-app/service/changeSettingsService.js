/**
 * Created by onyushkindv on 16.11.2016.
 */
var changeSettingsServices = angular.module('changeSettingsServices', []);

changeSettingsServices.service('ChangeSettingsService', ['$http', function($http) {

    this.getList = function () {
        return $http.get(backendServerAddr+'/api/shiftPersonals/Table', {timeout: backendTimeout, headers: getToken()});
    }

}]);