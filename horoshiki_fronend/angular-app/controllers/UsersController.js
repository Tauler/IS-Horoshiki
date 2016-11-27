/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

usersControllers.controller('UsersListController', ['$scope', '$location', 'UsersService', 'DictionaryService', 'PlatformsService',
    function ($scope, $location, UsersService, DictionaryService, PlatformsService) {
        $scope.model = {};
        $scope.model.users = [];
        $scope.model.paging = {};
        //текущая страница по умолчанию
        $scope.model.paging.PageNo = 1;
        //количество записей на страницу
        $scope.model.clientPageSize = 10;
        //количество кнопок на строке пагинации
        $scope.model.countPageButton = 5;
        $scope.model.orderby = {}
        $scope.model.orderby.field = 'Id';
        $scope.model.orderby.asc = true;

        $scope.model.filter = {};

        $scope.model.deleteUserModel = {};

        // Пагинация
        $scope.$watch('model.paging.PageNo', function () {
            $scope.getAllUsers();
        });

        $scope.getAllUsers = function () {
            var params = $scope.search();

            UsersService.getAllUsersParams($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc, params).success(function (result) {
                $scope.model.users = result.Data.Data;
                $scope.model.paging = result.Data.Paging;
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeStatuses = function () {
            DictionaryService.getEmployeeStatuses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.employeeStatuses = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.positions = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getDepartments = function () {
            DictionaryService.getDepartments().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.departments = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getPlatformsSmall = function () {
            PlatformsService.getAllSmall("Id", "True").success(function (result) {
                if (result.Success == 1) {
                    $scope.model.platforms = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.toAddUserPage = function () {
            $location.url("/users/add");
        }

        $scope.changeSort = function (fieldName, asc) {
            $scope.model.orderby.field = fieldName;
            $scope.model.orderby.asc = asc;
            $scope.getAllUsers();
        }
        // $scope.getAllUsers();

        $scope.deleteUserModal = function (deleteObject) {
            $scope.model.deleteUserModel = deleteObject;
        }

        $scope.deleteUser = function () {
            UsersService.userDetete($scope.model.deleteUserModel).success(function (result) {
                if (result.Success == 1) {
                    $scope.getAllUsers();
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });

            $scope.model.deleteUserModel = {};
        }

        $scope.deleteUserClose = function () {
            $scope.model.deleteUserModel = {};
        }

        $scope.search = function () {
            var params = '';
            if ($scope.model.filter.firstName != undefined && $scope.model.filter.firstName != '') {
                params += '&filterLastName=' + $scope.model.filter.firstName;
            }
            if ($scope.model.filter.isAccess != undefined && $scope.model.filter.isAccess != '') {
                params += '&filterIsAccess=' + $scope.model.filter.isAccess;
            }
            if ($scope.model.filter.employeeStatusId != undefined && $scope.model.filter.employeeStatusId != '') {
                params += '&filterEmployeeStatusId=' + $scope.model.filter.employeeStatusId;
            }
            if ($scope.model.filter.positionId != undefined && $scope.model.filter.positionId != '') {
                params += '&filterPositionId=' + $scope.model.filter.positionId;
            }
            if ($scope.model.filter.departmentId != undefined && $scope.model.filter.departmentId != '') {
                params += '&filterDepartmentId=' + $scope.model.filter.departmentId;
            }
            if ($scope.model.filter.platformId != undefined && $scope.model.filter.platformId != '') {
                params += '&filterPlatformId=' + $scope.model.filter.platformId;
            }
            if ($scope.model.filter.medicalBook != undefined && $scope.model.filter.medicalBook != '') {
                params += '&filterIsHaveMedicalBook=' + $scope.model.filter.medicalBook;
            }
            return params;
        }

        $scope.getEmployeeStatuses();
        $scope.getPositions();
        $scope.getDepartments();
        $scope.getPlatformsSmall();
    }
]);

usersControllers.controller('UsersAddController', ['$scope', '$rootScope', '$location', 'UsersService', 'DictionaryService', 'PlatformsService',
    function ($scope, $rootScope, $location, UsersService, DictionaryService, PlatformsService) {
        $scope.model = {};
        $scope.model.user = {
            "Id": "6",
            "FirstName": "",
            "MiddleName": "",
            "LastName": "",
            "Phone": "",
            "IsHaveMedicalBook": false,
            "MedicalBookEnd": "",
            "EmployeeStatus": "",
            "Position": "",
            "DateStart": "",
            "DateEnd": "",
            "IsAccess": false,
            "UserName": "",
            "Password": "",
            "ConfirmPassword": "",
            "Department": "",
            "SubDepartment": ""
        }
        $scope.model.user.IsAccess = true;

        $scope.model.Platform = {};
        $scope.model.Department = {};
        $scope.model.SubDepartment = {};

        //datepicker startDate init
        $scope.model.datepickerStartDate = {};
        $scope.model.datepickerStartDate.select = (new Date()).toDateString();
        $scope.model.datepickerStartDate.minMax = [];
        var date = new Date();
        date.setMonth(date.getMonth() + 12);
        $scope.model.datepickerStartDate.minMax[1] = dateFormatter(date); // maxDate
        date.setMonth(date.getMonth() - 24);
        $scope.model.datepickerStartDate.minMax[0] = dateFormatter(date); // minDate

        ////datepicker HaveMedicalBook init
        $scope.model.datepickerMedicalBook = {};
        $scope.model.datepickerMedicalBook.select = (new Date()).toDateString();
        $scope.model.datepickerMedicalBook.minMax = [];
        var date = new Date();
        date.setMonth(date.getMonth() + 12);
        $scope.model.datepickerMedicalBook.minMax[1] = dateFormatter(date); // maxDate
        date.setMonth(date.getMonth() - 24);
        $scope.model.datepickerMedicalBook.minMax[0] = dateFormatter(date); // minDate

        //errors init
        $scope.model.error = {};

        $scope.model.error.userNameExist = false;
        $scope.model.error.userName = false;
        $scope.checkErrorUserName = function () {
            UsersService.isExistUser($scope.model.user.UserName).success(function (result) {
                if (result.Success = 1) {
                    $scope.model.error.userNameExist = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })

            if ($scope.model.user.UserName.length < 3 || $scope.model.user.UserName.length > 50) {
                $scope.model.error.userName = true;
            } else {
                $scope.model.error.userName = false;
            }
        }

        $scope.model.error.password = false;
        $scope.checkErrorPassword = function () {
            if ($scope.model.user.Password.length < 6 || $scope.model.user.Password.length > 50) {
                $scope.model.error.password = true;
            } else {
                $scope.model.error.password = false;
            }
        }

        $scope.model.error.confirmPassword = false;
        $scope.checkErrorConfirmPassword = function () {
            if ($scope.model.user.Password != $scope.model.user.ConfirmPassword) {
                $scope.model.error.confirmPassword = true;
            } else {
                $scope.model.error.confirmPassword = false;
            }
        }

        $scope.model.error.firstName = false;
        $scope.checkErrorFirstName = function () {
            if ($scope.model.user.FirstName.length < 3 || $scope.model.user.FirstName.length > 50) {
                $scope.model.error.firstName = true;
            } else {
                $scope.model.error.firstName = false;
            }
        }

        $scope.model.error.lastName = false;
        $scope.checkErrorLastName = function () {
            if ($scope.model.user.LastName.length < 3 || $scope.model.user.LastName.length > 50) {
                $scope.model.error.lastName = true;
            } else {
                $scope.model.error.lastName = false;
            }
        }

        $scope.model.error.middleName = false;
        $scope.checkErrorMiddleName = function () {
            if ($scope.model.user.MiddleName.length < 3 || $scope.model.user.MiddleName.length > 50) {
                $scope.model.error.middleName = true;
            } else {
                $scope.model.error.middleName = false;
            }
        }

        $scope.model.error.phone = false;
        $scope.checkErrorPhone = function () {
            var phoneno = /^\d{10}$/;
            if (!$scope.model.user.Phone.match(phoneno)) {
                // if($scope.model.user.Phone.length != 11 || isInteger($scope.model.user.Phone)){
                $scope.model.error.phone = true;
            } else {
                $scope.model.error.phone = false;
            }
        }

        $scope.model.error.email = false;
        $scope.checkErrorEmail = function () {
            if ($scope.model.user.Email == undefined || !$scope.model.user.Email.match(mailRegexp)) {
                // if($scope.model.user.Phone.length != 11 || isInteger($scope.model.user.Phone)){
                $scope.model.error.email = true;
            } else {
                $scope.model.error.email = false;
            }
        }

        $scope.model.error.position = false;
        $scope.checkErrorPosition = function () {
            if ($scope.model.Position == "" || $scope.model.Position == undefined) {
                $scope.model.error.position = true;
            } else {
                $scope.model.error.position = false;
            }
        }

        $scope.model.error.platform = false;
        $scope.checkErrorPlatform = function () {
            if ($scope.model.Platform.Id == "" || $scope.model.Platform.Id == undefined) {
                $scope.model.error.platform = true;
            } else {
                $scope.model.error.platform = false;
            }
        }

        $scope.model.isUserManager = function () {
            if ($scope.model.Position != undefined || $scope.model.Position != '') {
                if (JSON.parse($scope.model.Position).Guid == enumPositions.manager) {
                    return true;
                }
            }
            return false;
        }

        $scope.model.error.isHaveMedicalBook = false;
        $scope.checkErrorIsHaveMedicalBook = function () {
            if (!$scope.model.user.IsHaveMedicalBook && !$scope.model.isUserManager()) {
                $scope.model.error.isHaveMedicalBook = true;
            } else {
                $scope.model.error.isHaveMedicalBook = false;
            }
        }

        $scope.model.error.datepickerMedicalBook = false;
        $scope.checkErrorDatepickerMedicalBook = function () {
            if (($scope.model.datepickerMedicalBook.select == undefined || $scope.model.datepickerMedicalBook.select == '') && !$scope.model.isUserManager()) {
                $scope.model.error.datepickerMedicalBook = true;
            } else {
                $scope.model.error.datepickerMedicalBook = false;
            }
        }

        $scope.model.error.datepickerStartDate = false;
        $scope.checkErrorDatepickerStartDate = function () {
            if ($scope.model.datepickerStartDate.select == undefined || $scope.model.datepickerStartDate.select == '') {
                $scope.model.error.datepickerStartDate = true;
            } else {
                $scope.model.error.datepickerStartDate = false;
            }
        }


        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.positions = [];

                    if ($rootScope.currentUser.Position.Guid == enumPositions.chiefOperatingOfficer) {
                        for (var i = 0, j = 0; i < result.Data.length; i++) {
                            if (result.Data[i].Guid != enumPositions.chiefOperatingOfficer) {
                                $scope.model.positions[j] = result.Data[i];
                                j++;
                            }
                        }
                    }
                    if ($rootScope.currentUser.Position.Guid == enumPositions.manager) {
                        for (var i = 0, j = 0; i < result.Data.length; i++) {
                            if (result.Data[i].Guid != enumPositions.chiefOperatingOfficer && result.Data[i].Guid != enumPositions.manager) {
                                $scope.model.positions[j] = result.Data[i];
                                j++;
                            }
                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getDepartments = function () {
            DictionaryService.getDepartments().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.departments = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }


        $scope.changeDepartment = function () {
            if ($scope.model.Department.Id != "") {
                $scope.getSubDepartments($scope.model.Department.Id);
            } else {
                $scope.model.isSubDepartmentsExisit = false;
                $scope.model.SubDepartment.Id = "";
            }
        }


        $scope.model.isSubDepartmentsExisit = false;
        $scope.model.error.subDepartments = false;
        $scope.checkErrorSubDepartments = function () {
            if (($scope.model.SubDepartment.Id == "" || $scope.model.SubDepartment.Id == undefined) && $scope.model.isSubDepartmentsExisit) {
                $scope.model.error.subDepartments = true;
            } else {
                $scope.model.error.subDepartments = false;
            }
        }


        $scope.getSubDepartments = function (id) {
            DictionaryService.getSubDepartmentsById(id).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subDepartments = result.Data;
                    if ($scope.model.subDepartments != null && $scope.model.subDepartments != 0) {
                        $scope.model.isSubDepartmentsExisit = true;
                    } else {
                        $scope.model.isSubDepartmentsExisit = false;
                        $scope.model.SubDepartment.Id = "";
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }


        $scope.getPlatformsSmall = function () {
            PlatformsService.getAllSmall("Id", "True").success(function (result) {
                if (result.Success == 1) {

                    if ($rootScope.currentUser.Position.Guid == enumPositions.manager) {
                        $scope.model.platforms = [];
                        $scope.model.platforms[0] = $rootScope.currentUser.Platform;
                        $scope.model.Platform.Id = $rootScope.currentUser.Platform.Id.toString();
                    } else {
                        $scope.model.platforms = result.Data;
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeStatuses = function () {
            DictionaryService.getEmployeeStatuses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.employeeStatuses = [];

                    for (var index in result.Data) {
                        if (result.Data[index].Guid != employeeStatus.dismissed) {
                            $scope.model.employeeStatuses[index] = result.Data[index];
                        }
                    }

                    for (var index in $scope.model.employeeStatuses) {
                        if ($scope.model.employeeStatuses[index].Guid == employeeStatus.trainee) {
                            $scope.model.EmployeeStatus = JSON.stringify($scope.model.employeeStatuses[index]);
                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.phoneToLogin = function () {
            $scope.checkErrorPhone();
            if (!$scope.model.error.phone) {
                $scope.model.user.UserName = $scope.model.user.Phone;
            }
        }

        $scope.mailToLogin = function () {
            $scope.checkErrorEmail();
            if (!$scope.model.error.email) {
                $scope.model.user.UserName = $scope.model.user.Email;
            }
        }

        $rootScope.$watch('currentUserLoaded', function () {
            if ($rootScope.currentUserLoaded == true) {
                $scope.getPositions();
                $scope.getPlatformsSmall();
            }
        });

        $scope.getDepartments();
        $scope.getEmployeeStatuses();


        $scope.saveUser = function () {
            $scope.checkErrorUserName();
            $scope.checkErrorPassword();
            $scope.checkErrorConfirmPassword();
            $scope.checkErrorFirstName();
            $scope.checkErrorLastName();
            $scope.checkErrorMiddleName();
            $scope.checkErrorPhone();
            $scope.checkErrorPosition();
            $scope.checkErrorPlatform();
            $scope.checkErrorIsHaveMedicalBook();
            $scope.checkErrorDatepickerMedicalBook();
            $scope.checkErrorSubDepartments();
            // $scope.checkErrorEmail();


            if (!$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.platform && !$scope.model.error.email && !$scope.model.error.userNameExist && !$scope.model.error.isHaveMedicalBook && !$scope.model.error.datepickerMedicalBook && !$scope.model.error.subDepartments
            ) {

                if ($scope.model.Position != "" && $scope.model.Position != undefined) {
                    $scope.model.user.Position = JSON.parse($scope.model.Position);
                }

                if ($scope.model.Department != "" && $scope.model.Department != undefined) {
                    $scope.model.user.Department = {};
                    if ($scope.model.Department.Id != undefined && $scope.model.Department.Id != '') {
                        $scope.model.user.Department.Id = parseInt($scope.model.Department.Id);
                    }
                }
                if ($scope.model.user.Department.Id == null && $scope.model.user.Department.Id == '') {
                    $scope.model.user.Department = null;
                }

                if ($scope.model.Platform != "" && $scope.model.Platform != undefined) {
                    $scope.model.user.Platform = {};
                    if ($scope.model.Platform.Id != undefined && $scope.model.Platform.Id != '') {
                        $scope.model.user.Platform.Id = parseInt($scope.model.Platform.Id);
                    }
                }

                if ($scope.model.user.Platform.Id == null && $scope.model.user.Platform.Id == '') {
                    $scope.model.user.Platform = null;
                }

                if ($scope.model.EmployeeStatus != "" && $scope.model.EmployeeStatus != undefined) {
                    $scope.model.user.EmployeeStatus = JSON.parse($scope.model.EmployeeStatus);
                }
                if ($scope.model.datepickerStartDate.select != "" && $scope.model.datepickerStartDate.select != undefined) {
                    $scope.model.user.DateStart = dateFormatterBackend($scope.model.datepickerStartDate.select);
                }

                // console.log($scope.model.datepickerMedicalBook.select);
                if ($scope.model.datepickerMedicalBook.select != '' && $scope.model.datepickerMedicalBook.select != undefined) {
                    $scope.model.user.MedicalBookEnd = dateFormatterBackend($scope.model.datepickerMedicalBook.select);
                }

                if ($scope.model.SubDepartment != "" && $scope.model.SubDepartment != undefined) {
                    $scope.model.user.SubDepartment = {};
                    if ($scope.model.SubDepartment.Id != undefined && $scope.model.SubDepartment.Id != '') {
                        $scope.model.user.SubDepartment.Id = parseInt($scope.model.SubDepartment.Id);
                    }
                }
                if ($scope.model.SubDepartment.Id == null && $scope.model.SubDepartment.Id == '') {
                    $scope.model.user.SubDepartment = null;
                }

                UsersService.userAdd($scope.model.user).success(function (result) {
                    if (result.Success == 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage(result.ReasonMessage);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }


        }

    }
]);

usersControllers.controller('UsersEditController', ['$scope', '$rootScope', '$location', 'UsersService', 'DictionaryService', '$routeParams', 'PlatformsService', 'ReasonDismissalService',
    function ($scope, $rootScope, $location, UsersService, DictionaryService, $routeParams, PlatformsService, ReasonDismissalService) {
        $scope.model = {};
        $scope.model.user = {
            "Id": "6",
            "FirstName": "",
            "MiddleName": "",
            "LastName": "",
            "Phone": "",
            "IsHaveMedicalBook": false,
            "MedicalBookEnd": "",
            "EmployeeStatus": "",
            "Position": "",
            "DateStart": "",
            "DateEnd": "",
            "IsAccess": false,
            "UserName": "",
            "Password": "",
            "ConfirmPassword": "",
            "Department": "",
            "EmployeeReasonDismissal": "",
            "SubDepartment": ""
        }

        $scope.model.user.IsAccess = true;

        $scope.model.Platform = {};
        $scope.model.Department = {};
        $scope.model.SubDepartment = {};
        $scope.model.ReasonDismissal = {};


        //datepicker startDate init
        $scope.model.datepickerStartDate = {};
        $scope.model.datepickerStartDate.minMax = [];
        var date = new Date();
        date.setMonth(date.getMonth() + 12);
        $scope.model.datepickerStartDate.minMax[1] = dateFormatter(date); // maxDate
        date.setMonth(date.getMonth() - 24);
        $scope.model.datepickerStartDate.minMax[0] = dateFormatter(date); // minDate

        ////datepicker HaveMedicalBook init
        $scope.model.datepickerMedicalBook = {};
        $scope.model.datepickerMedicalBook.minMax = [];
        var date = new Date();
        date.setMonth(date.getMonth() + 12);
        $scope.model.datepickerMedicalBook.minMax[1] = dateFormatter(date); // maxDate
        date.setMonth(date.getMonth() - 24);
        $scope.model.datepickerMedicalBook.minMax[0] = dateFormatter(date); // minDate


        ////datepicker HaveMedicalBook init
        $scope.model.datepickerEndDate = {};
        $scope.model.datepickerEndDate.minMax = [];
        var date = new Date();
        date.setMonth(date.getMonth() + 12);
        $scope.model.datepickerEndDate.minMax[1] = dateFormatter(date); // maxDate
        date.setMonth(date.getMonth() - 24);
        $scope.model.datepickerEndDate.minMax[0] = dateFormatter(date); // minDate


        //errors init
        $scope.model.error = {};

        $scope.model.error.password = false;
        $scope.checkErrorPassword = function () {
            if ($scope.model.user.Password.length < 6 || $scope.model.user.Password.length > 50) {
                $scope.model.error.password = true;
            } else {
                $scope.model.error.password = false;
            }
        }

        $scope.model.error.confirmPassword = false;
        $scope.checkErrorConfirmPassword = function () {
            if ($scope.model.user.Password != $scope.model.user.ConfirmPassword) {
                $scope.model.error.confirmPassword = true;
            } else {
                $scope.model.error.confirmPassword = false;
            }
        }

        $scope.model.error.firstName = false;
        $scope.checkErrorFirstName = function () {
            if ($scope.model.user.FirstName.length < 3 || $scope.model.user.FirstName.length > 50) {
                $scope.model.error.firstName = true;
            } else {
                $scope.model.error.firstName = false;
            }
        }

        $scope.model.error.lastName = false;
        $scope.checkErrorLastName = function () {
            if ($scope.model.user.LastName.length < 3 || $scope.model.user.LastName.length > 50) {
                $scope.model.error.lastName = true;
            } else {
                $scope.model.error.lastName = false;
            }
        }

        $scope.model.error.middleName = false;
        $scope.checkErrorMiddleName = function () {
            if ($scope.model.user.MiddleName.length < 3 || $scope.model.user.MiddleName.length > 50) {
                $scope.model.error.middleName = true;
            } else {
                $scope.model.error.middleName = false;
            }
        }

        $scope.model.error.phone = false;
        $scope.checkErrorPhone = function () {
            var phoneno = /^\d{10}$/;
            if (!$scope.model.user.Phone.match(phoneno)) {
                // if($scope.model.user.Phone.length != 11 || isInteger($scope.model.user.Phone)){
                $scope.model.error.phone = true;
            } else {
                $scope.model.error.phone = false;
            }
        }

        $scope.model.error.email = false;
        $scope.checkErrorEmail = function () {
            if ($scope.model.user.Email == undefined || !$scope.model.user.Email.match(mailRegexp)) {
                // if($scope.model.user.Phone.length != 11 || isInteger($scope.model.user.Phone)){
                $scope.model.error.email = true;
            } else {
                $scope.model.error.email = false;
            }
        }

        $scope.model.error.position = false;
        $scope.checkErrorPosition = function () {
            $scope.checkErrorIsHaveMedicalBook();
            $scope.checkErrorDatepickerMedicalBook();
            if ($scope.model.Position == "" || $scope.model.Position == undefined) {
                $scope.model.error.position = true;
            } else {
                $scope.model.error.position = false;
            }
        }

        $scope.model.error.reasonDismissal = false;
        $scope.checkErrorReasonDismissal = function () {
            if (($scope.model.ReasonDismissal.Id == undefined || $scope.model.ReasonDismissal.Id == "") && $scope.model.isDismissed) {
                $scope.model.error.reasonDismissal = true;
            } else {
                $scope.model.error.reasonDismissal = false;
            }
        }

        $scope.model.error.platform = false;
        $scope.checkErrorPlatform = function () {
            if ($scope.model.Platform.Id == "" || $scope.model.Platform.Id == undefined) {
                $scope.model.error.platform = true;
            } else {
                $scope.model.error.platform = false;
            }
        }

        // проверка уволен ли пользователь
        $scope.model.isDismissed = false;
        $scope.$watch('model.EmployeeStatus', function () {
            if ($scope.model.EmployeeStatus == undefined || $scope.model.EmployeeStatus == '' || JSON.parse($scope.model.EmployeeStatus).Guid != employeeStatus.dismissed) {
                $scope.model.isDismissed = false;
                $scope.model.user.IsAccess = true;
            } else {
                $scope.model.isDismissed = true;
                $scope.model.datepickerEndDate.select = new Date();
                $scope.model.user.IsAccess = false;
            }
        });

        $scope.model.error.isHaveMedicalBook = false;
        $scope.checkErrorIsHaveMedicalBook = function () {
            // console.log(!$scope.model.isUserManager);
            if (!$scope.model.user.IsHaveMedicalBook && !$scope.model.isUserManager()) {
                $scope.model.error.isHaveMedicalBook = true;
            } else {
                $scope.model.error.isHaveMedicalBook = false;
            }
        }

        $scope.model.error.datepickerMedicalBook = false;
        $scope.checkErrorDatepickerMedicalBook = function () {
            if (($scope.model.datepickerMedicalBook.select == undefined || $scope.model.datepickerMedicalBook.select == '') && !$scope.model.isUserManager()) {
                $scope.model.error.datepickerMedicalBook = true;
            } else {
                $scope.model.error.datepickerMedicalBook = false;
            }
        }

        $scope.model.error.datepickerStartDate = false;
        $scope.checkErrorDatepickerStartDate = function () {
            if ($scope.model.datepickerStartDate.select == undefined || $scope.model.datepickerStartDate.select == '') {
                $scope.model.error.datepickerStartDate = true;
            } else {
                $scope.model.error.datepickerStartDate = false;
            }
        }

        $scope.model.error.datepickerEndDate = false;
        $scope.checkErrorDatepickerEndDate = function () {
            if (($scope.model.datepickerEndDate.select == undefined || $scope.model.datepickerEndDate.select == '') && $scope.model.isDismissed) {
                $scope.model.error.datepickerEndDate = true;
            } else {
                $scope.model.error.datepickerEndDate = false;
            }
        }


        $scope.model.isUserManager = function () {
            if ($scope.model.Position != undefined || $scope.model.Position != '') {
                if (JSON.parse($scope.model.Position).Guid == enumPositions.manager) {
                    return true;
                }
            }
            return false;
        }

        // проверка происходит ли сейчас увольнение
        $scope.isDismissal = function () {
            if ($routeParams.dismissal != undefined && $routeParams.dismissal != '' && $routeParams.dismissal == 'true') {
                return true;
            } else {
                return false;
            }
        }

        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.positions = [];

                    if ($rootScope.currentUser.Position.Guid == enumPositions.chiefOperatingOfficer) {
                        for (var i = 0, j = 0; i < result.Data.length; i++) {
                            if (result.Data[i].Guid != enumPositions.chiefOperatingOfficer) {
                                $scope.model.positions[j] = result.Data[i];
                                j++;
                            }
                        }
                    }
                    if ($rootScope.currentUser.Position.Guid == enumPositions.manager) {
                        for (var i = 0, j = 0; i < result.Data.length; i++) {
                            if (result.Data[i].Guid != enumPositions.chiefOperatingOfficer && result.Data[i].Guid != enumPositions.manager) {
                                $scope.model.positions[j] = result.Data[i];
                                j++;
                            }
                            if (result.Data[i].Guid == enumPositions.manager && $rootScope.currentUser.Id == $scope.model.user.Id) {
                                $scope.model.positions[j] = result.Data[i];
                                j++;
                            }

                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeReasonDismissal = function () {
            ReasonDismissalService.getAllSmall('Id', 'true').success(function (result) {
                if (result.Success == 1) {
                    $scope.model.reasonDismissals = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getDepartments = function () {
            DictionaryService.getDepartments().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.departments = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.changeDepartment = function () {
            if ($scope.model.Department.Id != "") {
                $scope.getSubDepartments($scope.model.Department.Id);
            } else {
                $scope.model.isSubDepartmentsExisit = false;
                $scope.model.SubDepartment.Id = "";
            }
        }


        $scope.model.isSubDepartmentsExisit = false;
        $scope.model.error.subDepartments = false;
        $scope.checkErrorSubDepartments = function () {
            if (($scope.model.SubDepartment.Id == "" || $scope.model.SubDepartment.Id == undefined) && $scope.model.isSubDepartmentsExisit) {
                $scope.model.error.subDepartments = true;
            } else {
                $scope.model.error.subDepartments = false;
            }
        }


        $scope.getSubDepartments = function (id) {
            DictionaryService.getSubDepartmentsById(id).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subDepartments = result.Data;
                    if ($scope.model.subDepartments != null && $scope.model.subDepartments != 0) {
                        $scope.model.isSubDepartmentsExisit = true;
                    } else {
                        $scope.model.isSubDepartmentsExisit = false;
                        $scope.model.SubDepartment.Id = "";
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getPlatformsSmall = function () {
            PlatformsService.getAllSmall("Id", "True").success(function (result) {
                if (result.Success == 1) {

                    if ($rootScope.currentUser.Position.Guid == enumPositions.manager) {
                        $scope.model.platforms = [];
                        $scope.model.platforms[0] = $rootScope.currentUser.Platform;
                        $scope.model.Platform.Id = $rootScope.currentUser.Platform.Id.toString();
                    } else {
                        $scope.model.platforms = result.Data;
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        // $scope.getEmployeeStatuses = function () {
        //     DictionaryService.getEmployeeStatuses().success(function (result) {
        //         if (result.Success == 1) {
        //             $scope.model.employeeStatuses = result.Data;
        //
        //             for (var index in $scope.model.employeeStatuses) {
        //                 if ($scope.model.employeeStatuses[index].Id == 1) {
        //                     $scope.model.EmployeeStatus = JSON.stringify($scope.model.employeeStatuses[index]);
        //                 }
        //             }
        //         } else {
        //             displayErrorMessage(result.ReasonMessage);
        //         }
        //     }).error(function (result, status) {
        //         httpErrors($location.url(), status);
        //     })
        // }

        $scope.getUser = function () {
            // получаем id из параметра
            // $scope.currentUserId = $routeParams.userId;
            UsersService.getUser($routeParams.userId).success(function (result) {
                if (result.Success = 1) {

                    $scope.model.user = result.Data;

                    DictionaryService.getEmployeeStatuses().success(function (result) {
                        if (result.Success == 1) {
                            $scope.model.employeeStatuses = result.Data;
                            if ($scope.isDismissal()) {
                                $scope.model.datepickerEndDate.select = new Date();
                                for (var index in $scope.model.employeeStatuses) {
                                    if ($scope.model.employeeStatuses[index].Guid == employeeStatus.dismissed) {
                                        $scope.model.EmployeeStatus = JSON.stringify($scope.model.employeeStatuses[index]);
                                    }
                                }

                            } else {
                                $scope.model.EmployeeStatus = JSON.stringify($scope.model.user.EmployeeStatus);
                            }

                        } else {
                            displayErrorMessage(result.ReasonMessage);
                        }
                    }).error(function (result, status) {
                        httpErrors($location.url(), status);
                    });

                    if ($scope.model.user.EmployeeReasonDismissal != undefined && $scope.model.user.EmployeeReasonDismissal.Id != undefined && $scope.model.user.EmployeeReasonDismissal.Id != '') {
                        $scope.ReasonDismissal = {};
                        $scope.model.ReasonDismissal.Id = $scope.model.user.EmployeeReasonDismissal.Id.toString();
                    }

                    $scope.model.datepickerStartDate.select = $scope.model.user.DateStart;
                    $scope.model.datepickerMedicalBook.select = $scope.model.user.MedicalBookEnd;
                    $scope.model.datepickerEndDate.select = $scope.model.user.DateEnd;

                    $scope.model.Position = JSON.stringify($scope.model.user.Position);

                    if ($scope.model.user.Department != undefined && $scope.model.user.Department.Id != '') {
                        $scope.model.Department.Id = $scope.model.user.Department.Id.toString();
                        $scope.changeDepartment();
                    }
                    // $scope.model.Platform = JSON.stringify($scope.model.user.Platform);
                    if ($scope.model.user.Platform != undefined && $scope.model.user.Platform.Id != '') {
                        $scope.model.Platform.Id = $scope.model.user.Platform.Id.toString();
                    }

                    if ($scope.model.user.SubDepartment != undefined && $scope.model.user.SubDepartment.Id != '') {
                        $scope.model.SubDepartment.Id = $scope.model.user.SubDepartment.Id.toString();
                    }

                    $scope.model.user.Password = null;
                    $scope.model.user.ConfirmPassword = null;


                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.phoneToLogin = function () {
            $scope.checkErrorPhone();
            if (!$scope.model.error.phone) {
                $scope.model.user.UserName = $scope.model.user.Phone;
            }
        }


        $scope.mailToLogin = function () {
            $scope.checkErrorEmail();
            if (!$scope.model.error.email) {
                $scope.model.user.UserName = $scope.model.user.Email;
            }
        }


        $rootScope.$watch('currentUserLoaded', function () {
            if ($rootScope.currentUserLoaded == true) {
                $scope.getPositions();
                $scope.getPlatformsSmall();
            }
        });

        $scope.getEmployeeReasonDismissal();
        $scope.getDepartments();
        $scope.getUser();

        $scope.saveUser = function () {

            // $scope.checkErrorUserName();
            // $scope.checkErrorPassword();
            // $scope.checkErrorConfirmPassword();
            $scope.checkErrorPlatform();
            $scope.checkErrorFirstName();
            $scope.checkErrorLastName();
            $scope.checkErrorMiddleName();
            $scope.checkErrorPhone();
            $scope.checkErrorPosition();
            $scope.checkErrorReasonDismissal();
            $scope.checkErrorDatepickerEndDate();
            $scope.checkErrorSubDepartments();


            // $scope.checkErrorEmail();

            if (!$scope.model.error.reasonDismissal && !$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.platform && !$scope.model.error.email && !$scope.model.error.userNameExist && !$scope.model.error.isHaveMedicalBook && !$scope.model.error.datepickerMedicalBook && !$scope.model.error.datepickerEndDate && !$scope.model.error.subDepartments
            ) {

                if ($scope.model.Position != "" && $scope.model.Position != undefined) {
                    $scope.model.user.Position = JSON.parse($scope.model.Position);
                }


                // if($scope.isDismissal() || $scope.isDismissed()) {
                if ($scope.model.ReasonDismissal != "" && $scope.model.ReasonDismissal != undefined) {
                    $scope.model.user.EmployeeReasonDismissal = {};
                    if ($scope.model.ReasonDismissal.Id != undefined && $scope.model.ReasonDismissal.Id != '') {
                        $scope.model.user.EmployeeReasonDismissal.Id = parseInt($scope.model.ReasonDismissal.Id);
                    }
                }
                if ($scope.model.user.EmployeeReasonDismissal == null || $scope.model.user.EmployeeReasonDismissal.Id == null || $scope.model.user.EmployeeReasonDismissal.Id == '') {
                    $scope.model.user.EmployeeReasonDismissal = null;
                }
                // }

                if ($scope.model.Department != "" && $scope.model.Department != undefined) {
                    $scope.model.user.Department = {};
                    if ($scope.model.Department.Id != undefined && $scope.model.Department.Id != '') {
                        $scope.model.user.Department.Id = parseInt($scope.model.Department.Id);
                    }
                }
                if ($scope.model.user.Department.Id == null && $scope.model.user.Department.Id == '') {
                    $scope.model.user.Department = null;
                }

                if ($scope.model.Platform != "" && $scope.model.Platform != undefined) {
                    $scope.model.user.Platform = {};
                    if ($scope.model.Platform.Id != undefined && $scope.model.Platform.Id != '') {
                        $scope.model.user.Platform.Id = parseInt($scope.model.Platform.Id);
                    }
                }
                if ($scope.model.user.Platform.Id == null && $scope.model.user.Platform.Id == '') {
                    $scope.model.user.Platform = null;
                }

                if ($scope.model.EmployeeStatus != "" && $scope.model.EmployeeStatus != undefined) {
                    $scope.model.user.EmployeeStatus = JSON.parse($scope.model.EmployeeStatus);
                }
                if ($scope.model.datepickerStartDate.select != "" && $scope.model.datepickerStartDate.select != undefined) {
                    $scope.model.user.DateStart = dateFormatterBackend($scope.model.datepickerStartDate.select);
                }
                if ($scope.model.datepickerMedicalBook.select != "" && $scope.model.datepickerMedicalBook.select != undefined) {
                    $scope.model.user.MedicalBookEnd = dateFormatterBackend($scope.model.datepickerMedicalBook.select);
                }

                if ($scope.model.datepickerEndDate.select != "" && $scope.model.datepickerEndDate.select != undefined) {
                    $scope.model.user.DateEnd = dateFormatterBackend($scope.model.datepickerEndDate.select);
                }

                if ($scope.model.SubDepartment != "" && $scope.model.SubDepartment != undefined) {
                    $scope.model.user.SubDepartment = {};
                    if ($scope.model.SubDepartment.Id != undefined && $scope.model.SubDepartment.Id != '') {
                        $scope.model.user.SubDepartment.Id = parseInt($scope.model.SubDepartment.Id);
                    }
                }
                if ($scope.model.SubDepartment.Id == null && $scope.model.SubDepartment.Id == '') {
                    $scope.model.user.SubDepartment = null;
                }

                UsersService.userEdit($scope.model.user).success(function (result) {
                    if (result.Success == 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage(result.ReasonMessage);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }
        }

    }
]);

usersControllers.controller('UsersEditPasswordController', ['$scope', '$location', 'UsersService', 'DictionaryService', '$routeParams',
    function ($scope, $location, UsersService, DictionaryService, $routeParams) {
        $scope.model = {};
        // $scope.model.userPassword = {}
        $scope.model.userPassword = {
            UserId: "",
            Password: "",
            ConfirmPassword: ""
        }


        //errors init
        $scope.model.error = {};

        $scope.model.error.password = false;
        $scope.checkErrorPassword = function () {
            if ($scope.model.userPassword.Password.length < 6 || $scope.model.userPassword.Password.length > 50) {
                $scope.model.error.password = true;
            } else {
                $scope.model.error.password = false;
            }
        }

        $scope.model.error.confirmPassword = false;
        $scope.checkErrorConfirmPassword = function () {
            if ($scope.model.userPassword.Password != $scope.model.userPassword.ConfirmPassword) {
                $scope.model.error.confirmPassword = true;
            } else {
                $scope.model.error.confirmPassword = false;
            }
        }

        $scope.changeUserPassword = function () {

            $scope.checkErrorPassword();
            $scope.checkErrorConfirmPassword();

            $scope.model.userPassword.UserId = $routeParams.userId;

            if (!$scope.model.error.password && !$scope.model.error.confirmPassword) {
                UsersService.setPassword($scope.model.userPassword).success(function (result) {
                    if (result.Success == 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage(result.ReasonMessage);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }
        }

    }
]);