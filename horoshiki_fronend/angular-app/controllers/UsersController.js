/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

usersControllers.controller('UsersViewController', ['$scope', '$location', 'UsersService', 'DictionaryService', 'PlatformsService',
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
            if ($scope.model.filter.positionId != undefined && $scope.model.filter.positionId != ''){
                params += '&filterPositionId=' + $scope.model.filter.positionId;
            }
            if ($scope.model.filter.departmentId != undefined && $scope.model.filter.departmentId != ''){
                params += '&filterDepartmentId=' + $scope.model.filter.departmentId;
            }
            if ($scope.model.filter.platformId != undefined && $scope.model.filter.platformId != ''){
                params += '&filterPlatformId=' + $scope.model.filter.platformId;
            }
            if ($scope.model.filter.medicalBook != undefined && $scope.model.filter.medicalBook != ''){
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

usersControllers.controller('UsersAddController', ['$scope', '$location', 'UsersService', 'DictionaryService', 'PlatformsService',
    function ($scope, $location, UsersService, DictionaryService, PlatformsService) {
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
            "Department": ""
        }
        $scope.model.user.IsAccess = true;

        $scope.model.Platform = {};
        $scope.model.Department = {};


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
            // if ($scope.model.Platform.Id == "" || $scope.model.Platform.Id == undefined) {
            //     $scope.model.error.platform = true;
            // } else {
            //     $scope.model.error.platform = false;
            // }
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
                        if ($scope.model.employeeStatuses[index].Guid == employeeStatus.worked) {
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

        $scope.getPositions();
        $scope.getDepartments();
        $scope.getEmployeeStatuses();
        $scope.getPlatformsSmall()

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
            // $scope.checkErrorEmail();


            if (!$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.platform && !$scope.model.error.email && !$scope.model.error.userNameExist
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
                if ($scope.model.datepickerMedicalBook.select != "" && $scope.model.datepickerMedicalBook.select != undefined) {
                    $scope.model.user.MedicalBookEnd = dateFormatterBackend($scope.model.datepickerMedicalBook.select);
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

usersControllers.controller('UsersEditController', ['$scope', '$location', 'UsersService', 'DictionaryService', '$routeParams', 'PlatformsService', 'ReasonDismissalService',
    function ($scope, $location, UsersService, DictionaryService, $routeParams, PlatformsService, ReasonDismissalService) {
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
            "EmployeeReasonDismissal": ""
        }

        $scope.model.Platform = {};
        $scope.model.Department = {};
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
            if ($scope.model.Position == "" || $scope.model.Position == undefined) {
                $scope.model.error.position = true;
            } else {
                $scope.model.error.position = false;
            }
        }

        $scope.model.error.reasonDismissal = false;
        $scope.checkErrorReasonDismissal = function () {

            console.log($scope.model.ReasonDismissal.Id);

            if (($scope.model.ReasonDismissal.Id == undefined || $scope.model.ReasonDismissal.Id == "") && $scope.model.isDismissed) {
                $scope.model.error.reasonDismissal = true;
            } else {
                $scope.model.error.reasonDismissal = false;
            }

            console.log($scope.model.error.reasonDismissal);
        }

        $scope.model.error.platform = false;
        $scope.checkErrorPlatform = function () {
            // if ($scope.model.Platform.Id == "" || $scope.model.Platform.Id == undefined) {
            //     $scope.model.error.platform = true;
            // } else {
            //     $scope.model.error.platform = false;
            // }
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
                    $scope.model.positions = result.Data;
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

        $scope.getPlatformsSmall = function () {
            PlatformsService.getAllSmall("Id", "True").success(function (result) {
                if (result.Success == 1) {
                    $scope.model.platforms = result.Data;
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
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
                    }
                    // $scope.model.Platform = JSON.stringify($scope.model.user.Platform);
                    if ($scope.model.user.Platform != undefined && $scope.model.user.Platform.Id != '') {
                        $scope.model.Platform.Id = $scope.model.user.Platform.Id.toString();
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

        $scope.getEmployeeReasonDismissal();
        $scope.getPositions();
        $scope.getDepartments();
        $scope.getPlatformsSmall();
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

            // $scope.checkErrorEmail();

            if (!$scope.model.error.reasonDismissal && !$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.platform && !$scope.model.error.email && !$scope.model.error.userNameExist
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