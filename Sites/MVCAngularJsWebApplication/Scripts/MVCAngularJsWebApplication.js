var mvcAngularJsWebApplication = angular.module('mvcAngularJsWebApplication', ['ngRoute', 'ui.grid']);

mvcAngularJsWebApplication.factory('LoginFactory', LoginFactory);
mvcAngularJsWebApplication.factory('LinksFactory', LinksFactory);
mvcAngularJsWebApplication.factory('RegistrationFactory', RegistrationFactory);
mvcAngularJsWebApplication.controller('PlacesController', PlacesController);
mvcAngularJsWebApplication.controller('MainController', MainController);
mvcAngularJsWebApplication.controller('AboutController', AboutController);
mvcAngularJsWebApplication.controller('ContactController', ContactController);
mvcAngularJsWebApplication.controller('AccountController', AccountController);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Home/Main',
            controller: MainController
        })
        // route for the about page
        .when('/about', {
            templateUrl: 'About',
            controller: AboutController
        })
        // route for the contact page
        .when('/contact', {
            templateUrl: 'Contact',
            controller: ContactController
        })
            // route for the contact page
        .when('/links', {
            templateUrl: 'Places',
            controller: PlacesController
        })
        .when('/login', {
            templateUrl: 'Account/Login',
            controller: AccountController
        });

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
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];
mvcAngularJsWebApplication.config(configFunction);