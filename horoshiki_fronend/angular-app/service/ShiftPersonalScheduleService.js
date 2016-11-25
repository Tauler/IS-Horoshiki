/**
 * Created by onyushkindv on 10.10.2016.
 */

var shiftPersonalScheduleServices = angular.module('shiftPersonalScheduleServices', []);

shiftPersonalScheduleServices.service('ShiftPersonalScheduleService', ['$http', function($http) {

    this.table = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/shiftPersonalSchedule/table',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.updateCell = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/shiftPersonalSchedule/updateCell',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };
	
	this.normaHour = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/shiftPersonalSchedule/normaHour',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };
    
    this.getById = function (id) {
        var resp = $http({
            url: backendServerAddr+'/api/shiftPersonalSchedule/'+id,
            method: 'DELETE',
            headers:  getToken()
        });
        return resp;
    };
    
}]);