/**
 * Created by onyushkindv on 24.10.2016.
 */
var salesPlanServices = angular.module('salesPlanServices', []);

salesPlanServices.service('SalesPlanService', ['$http', function($http) {
    this.add = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/salePlan/add',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.edit = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/salePlan/Update',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    };

    this.editCall = function (object) {
        var resp = $http({
            url: backendServerAddr+'/api/salePlan/UpdateCell',
            method: 'POST',
            data: object,
            headers:  getToken()
        });
        return resp;
    }

}]);