/**
 * Created by onyushkindv on 25.08.2016.
 */

var usersControllers = angular.module('usersControllers', []);

usersControllers.controller('UsersViewController', ['$scope', '$location', 'UsersService',
    function ($scope, $location, UsersService) {
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

        // Пагинация
        $scope.$watch('model.paging.PageNo', function () {
            $scope.getAllUsers();
        });

        $scope.getAllUsers = function () {
            UsersService.getAllUsers($scope.model.paging.PageNo, $scope.model.clientPageSize, $scope.model.orderby.field, $scope.model.orderby.asc).success(function (result) {
                $scope.model.users = result.Data.Data;
                $scope.model.paging = result.Data.Paging;
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
        $scope.getAllUsers();
    }
]);

usersControllers.controller('UsersAddController', ['$scope', '$location', 'UsersService', 'DictionaryService',
    function ($scope, $location, UsersService, DictionaryService) {
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
            "ConfirmPassword": ""
        }
        $scope.model.user.IsAccess = true;


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
                    displayErrorMessage($scope.translation[result.reason]);
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

        $scope.model.error.position = false;
        $scope.checkErrorPosition = function () {
            if ($scope.model.Position == "" || $scope.model.Position == undefined) {
                $scope.model.error.position = true;
            } else {
                $scope.model.error.position = false;
            }
        }


        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.positions = result.Data;
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeStatuses = function () {
            DictionaryService.getEmployeeStatuses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.employeeStatuses = result.Data;

                    for (var index in $scope.model.employeeStatuses) {
                        if ($scope.model.employeeStatuses[index].Id == 1) {
                            $scope.model.EmployeeStatus = JSON.stringify($scope.model.employeeStatuses[index]);
                        }
                    }
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getPositions();
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

            if (!$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.userNameExist
            ) {

                if ($scope.model.Position != "" && $scope.model.Position != undefined) {
                    $scope.model.user.Position = JSON.parse($scope.model.Position);
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

                UsersService.userAdd($scope.model.user).success(function (result) {
                    if (result.Success = 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage($scope.translation[result.reason]);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }


        }

    }
]);

usersControllers.controller('UsersEditController', ['$scope', '$location', 'UsersService', 'DictionaryService', '$routeParams',
    function ($scope, $location, UsersService, DictionaryService, $routeParams) {
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
            "ConfirmPassword": ""
        }


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

        $scope.model.error.position = false;
        $scope.checkErrorPosition = function () {
            if ($scope.model.Position == "" || $scope.model.Position == undefined) {
                $scope.model.error.position = true;
            } else {
                $scope.model.error.position = false;
            }
        }


        $scope.getPositions = function () {
            DictionaryService.getPositions().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.positions = result.Data;
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getEmployeeStatuses = function () {
            DictionaryService.getEmployeeStatuses().success(function (result) {
                if (result.Success == 1) {
                    $scope.model.employeeStatuses = result.Data;

                    for (var index in $scope.model.employeeStatuses) {
                        if ($scope.model.employeeStatuses[index].Id == 1) {
                            $scope.model.EmployeeStatus = JSON.stringify($scope.model.employeeStatuses[index]);
                        }
                    }
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getUser = function () {
            // получаем id из параметра
            // $scope.currentUserId = $routeParams.userId;
            UsersService.getUser($routeParams.userId).success(function (result) {
                if (result.Success = 1) {
                    $scope.model.user = result.Data;

                    $scope.model.datepickerStartDate.select = $scope.model.user.DateStart;
                    $scope.model.datepickerMedicalBook.select = $scope.model.user.MedicalBookEnd;

                    $scope.model.EmployeeStatus = JSON.stringify($scope.model.user.EmployeeStatus);
                    $scope.model.Position = JSON.stringify($scope.model.user.Position);

                    $scope.model.user.Password = null;
                    $scope.model.user.ConfirmPassword = null;
                } else {
                    displayErrorMessage($scope.translation[result.reason]);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            })
        }

        $scope.getPositions();
        $scope.getEmployeeStatuses();
        $scope.getUser();

        $scope.saveUser = function () {

            // $scope.checkErrorUserName();
            // $scope.checkErrorPassword();
            // $scope.checkErrorConfirmPassword();
            $scope.checkErrorFirstName();
            $scope.checkErrorLastName();
            $scope.checkErrorMiddleName();
            $scope.checkErrorPhone();
            $scope.checkErrorPosition();

            if (!$scope.model.error.userName && !$scope.model.error.password && !$scope.model.error.confirmPassword && !$scope.model.error.firstName && !$scope.model.error.lastName && !$scope.model.error.middleName && !$scope.model.error.phone && !$scope.model.error.position && !$scope.model.error.userNameExist
            ) {

                if ($scope.model.Position != "" && $scope.model.Position != undefined) {
                    $scope.model.user.Position = JSON.parse($scope.model.Position);
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

                UsersService.userEdit($scope.model.user).success(function (result) {
                    if (result.Success = 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage($scope.translation[result.reason]);
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
        $scope.model.userPassword = {
            "Id": "",
            "NewPassword": "",
            "ConfirmPassword": ""
        }


        //errors init
        $scope.model.error = {};

        $scope.model.error.password = false;
        $scope.checkErrorPassword = function () {
            if ($scope.model.userPassword.NewPassword.length < 6 || $scope.model.userPassword.NewPassword.length > 50) {
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

            $scope.model.userPassword.Id = $routeParams.userId;

            if (!$scope.model.error.password && !$scope.model.error.confirmPassword) {
                UsersService.setPassword($scope.model.userPassword).success(function (result) {
                    if (result.Success = 1) {
                        $location.url("/users");
                    } else {
                        displayErrorMessage($scope.translation[result.reason]);
                    }
                }).error(function (result, status) {
                    httpErrors($location.url(), status);
                })
            }
        }

    }
]);