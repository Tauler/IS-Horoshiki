/**
 * Created by onyushkindv on 19.08.2016.
 */

var horoshikiApp = angular.module('horoshikiApp', [
    'ngRoute',
    'ngSanitize',
    'ngResource',
    'ngCookies',
    'yaMap',
    'ui.bootstrap.pagination',
    // 'ui.bootstrap.datepicker',
    'datepickerDirectives',
    'layoutControllers',
    'errorControllers',
    'mainControllers',
    'usersControllers',
    'subdivisionsControllers',

    'backendServices',
    'accountServices',
    'translationServices',
    'usersServices',
    'dictionaryServices',
    'subdivisionsServices'

]);

horoshikiApp.config(['$locationProvider', '$httpProvider', '$routeProvider',
    function($locationProvider, $httpProvider, $routeProvider) {
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/', {
                templateUrl: '/angular-html/main.view.html',
                controller: 'MainViewController',
                pageId: 'mainViewPage',
                groupId: 'metric',
                subgroupId: 'main',
                title: 'Главная страница'
            })
            .when('/users/add', {
                templateUrl: '/angular-html/users.add.html',
                controller: 'UsersAddController',
                pageId: 'usersAddPage',
                groupId: 'settings',
                subgroupId: 'users',
                title: 'Добавление пользователя'
            })
            .when('/users/edit/:userId', {
                templateUrl: '/angular-html/users.edit.html',
                controller: 'UsersEditController',
                pageId: 'usersEditPage',
                groupId: 'settings',
                subgroupId: 'users',
                title: 'Изменение пользователя'
            })
            .when('/users/editPassword/:userId', {
                templateUrl: '/angular-html/users.password.edit.html',
                controller: 'UsersEditPasswordController',
                pageId: 'usersEditPasswordPage',
                groupId: 'settings',
                subgroupId: 'users',
                title: 'Изменение пользователя'
            })
            .when('/users', {
                templateUrl: '/angular-html/users.view.html',
                controller: 'UsersViewController',
                pageId: 'usersViewPage',
                groupId: 'settings',
                subgroupId: 'users',
                title: 'Просмотр пользователей'
            })
            .when('/subdivisions', {
                templateUrl: '/angular-html/subdivisions.view.html',
                controller: 'SubdivisionViewController',
                pageId: 'subdivisionViewPage',
                groupId: 'settings',
                subgroupId: 'subdivisions',
                title: 'Просмотр подразделений'
            })

            .when('/error', {
                templateUrl: '/angular-html/error.view.html',
                controller: 'ErrorViewController',
                title: 'Что-то пошло не так ...'
            })
            .otherwise({
                redirectTo: '/'
            });
    }
]);

horoshikiApp.run(['$route', '$rootScope', '$location', function ($route, $rootScope, $location) {
    var original = $location.path;
    $location.path = function (path, reload) {
        if (reload === false) {
            var lastRoute = $route.current;
            var un = $rootScope.$on('$locationChangeSuccess', function () {
                $route.current = lastRoute;
                un();
            });
        }
        return original.apply($location, [path]);
    }
}]);

var horoshikiAppLogin = angular.module('horoshikiAppLogin', [
    'ngRoute',
    'ngSanitize',
    'ngResource',
    'ngCookies',
    'layoutControllers',
    'loginControllers',
    'errorControllers',
    'translationServices',
    'backendServices',
    'accountServices'
]);

horoshikiAppLogin.config(['$locationProvider', '$httpProvider', '$routeProvider',
    function($locationProvider, $httpProvider, $routeProvider) {
        // $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
        // $httpProvider.defaults.xsrfHeaderName = "X-CSRF-TOKEN";
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/account/login', {
                templateUrl: '/angular-html/login.view.html',
                controller: 'LoginViewController',
                title: 'Авторизация'
            })
            .otherwise({
                redirectTo: '/account/login'
            });
    }
]);