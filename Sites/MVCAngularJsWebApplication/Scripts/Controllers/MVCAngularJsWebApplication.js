var mvcAngularJsWebApplication = angular.module('mvcAngularJsWebApplication', ['ngRoute']);

mvcAngularJsWebApplication.factory('LoginFactory', LoginFactory);
mvcAngularJsWebApplication.factory('RegistrationFactory', RegistrationFactory);
mvcAngularJsWebApplication.controller('LandingPageController', LandingPageController);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
       when('/routeOne', {
           templateUrl: 'RoutesDemo/One'
       })
       .when('/routeTwo/:donuts', {
           templateUrl: function (params) { return '/RoutesDemo/Two?donuts=' + params.donuts; }
       })
       .when('/routeThree', {
           templateUrl: 'RoutesDemo/Three'
       })
    .when('/login', {
        templateUrl: 'Account/Login',
        controller: LoginController
})
    .when('/register', {
        templateUrl: 'Account/Register',
        controller: RegisterController
        })    
    ;

    $httpProvider.interceptors.push(['$q', '$location', function ($q, $location) {
        return {
            response: function (response) {
                if (response.status === 401) {
                    console.log("Response 401");
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    console.log("Response Error 401", rejection);
                    $location.path('/login').search('returnUrl', $location.path());
                    alert("Response Error 401");

                }
                return $q.reject(rejection);
            }
        };
    }]);
    //$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];
mvcAngularJsWebApplication.config(configFunction);