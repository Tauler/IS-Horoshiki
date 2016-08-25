/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersServices = angular.module('usersServices', []);

accountServices.service('UsersService', ['$http', function ($http) {


    this.getAllUsers = function () {

        // var user = {
        //     Id: 1,
        //     FirstName: 'Василий',
        //     MiddleName: 'Петрович',
        //     LastName: 'Петров',
        //     Phone: '+79373332251',
        //     IsHaveMedicalBook: true,
        //     MedicalBookEnd: '2016-08-25T09:55:07.2704348+03:00',
        //     EmployeeStatus: {Id: 1, Value: 'Employee Status 1'},
        //     Position: {Id: 1, Value: 'Position 1'},
        //     DateStart : '',
        //     DateEnd : '',
        //     IsAccess : true,
        //     UserName : 'test'
        // };

        var users = [];

        // var resp = $http({
        //     url: backendServerAddr+'/token',
        //     method: 'POST',
        //     data: $.param({ grant_type: 'password', username: username, password: password }),
        //     headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        // });
        return resp;
    };

}]);