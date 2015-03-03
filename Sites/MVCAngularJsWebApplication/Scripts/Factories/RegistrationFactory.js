var RegistrationFactory = function ($http, $q) {
    return function (emailAddress, password, confirmPassword) {

        var deferredObject = $q.defer();

        $http.post(
            '/Account/Register', {
                Email: emailAddress,
                Password: password,
                ConfirmPassword: confirmPassword
            }
        )
            .success(function (data) {
                if (data == "True") {
                    deferredObject.resolve({ success: true });
                } else {
                    deferredObject.resolve({ success: false });
                }
            })
            .error(function () {
                deferredObject.resolve({ success: false });
            });

        return deferredObject.promise;
    }
}

RegistrationFactory.$inject = ['$http', '$q'];

////var LandingPageController = function (n) { n.models = { helloAngular: "I Work!" } },
////    LoginController, MVCAngularJsWebApplication, configFunction, RegisterController, AuthHttpResponseInterceptor, LoginFactory, RegistrationFactory;
////LandingPageController.$inject = ["$scope"];
////LoginController = function (n, t, i, r) {
////    n.loginForm = { emailAddress: "", password: "", rememberMe: !1, returnUrl: t.returnUrl, loginFailure: !1 };
////    n.login = function () {
////        var t = r(n.loginForm.emailAddress, n.loginForm.password, n.loginForm.rememberMe);
////        t.then(function (t) { t.success ? n.loginForm.returnUrl !== undefined ? i.path("/routeOne") : i.path(n.loginForm.returnUrl) : n.loginForm.loginFailure = !0 })
////    }
////};
////LoginController.$inject = ["$scope", "$routeParams", "$location", "LoginFactory"];
////MVCAngularJsWebApplication = angular.module("MVCAngularJsWebApplication", ["ngRoute"]);
////MVCAngularJsWebApplication.controller("LandingPageController", LandingPageController);
////MVCAngularJsWebApplication.factory("LoginFactory", LoginFactory);
////MVCAngularJsWebApplication.controller("LoginController", LoginController);
////MVCAngularJsWebApplication.factory("RegistrationFactory", RegistrationFactory);
////MVCAngularJsWebApplication.controller("RegisterController", RegisterController);
////configFunction = function (n, t) { n.when("/routeOne", { templateUrl: "routesDemo/one" }).when("/routeTwo/:donuts", { templateUrl: function (n) { return "/routesDemo/two?donuts=" + n.donuts } }).when("/routeThree", { templateUrl: "routesDemo/three" }).when("/login", { templateUrl: "/Account/Login", controller: LoginController }).when("/register", { templateUrl: "/Account/Register", controller: RegisterController }); t.interceptors.push(["$q", "$location", function (n, t) { return { response: function (t) { return t.status === 401 && console.log("Response 401"), t || n.when(t) }, responseError: function (i) { return i.status === 401 && (console.log("Response Error 401", i), t.path("/login").search("returnUrl", t.path())), n.reject(i) } } }]) }; configFunction.$inject = ["$routeProvider", "$httpProvider"]; MVCAngularJsWebApplication.config(configFunction); RegisterController = function (n, t, i) {
////    n.registerForm = { emailAddress: "", password: "", confirmPassword: "", registrationFailure: !1 }; n.register = function () {
////        alert(n.registerForm.emailAddress);
////        var r = i(n.registerForm.emailAddress, n.registerForm.password, n.registerForm.confirmPassword); r.then(function (i) { i.success ? t.path("/routeOne") : n.registerForm.registrationFailure = !0 })
////    }
////}; RegisterController.$inject = ["$scope", "$location", "RegistrationFactory"]; AuthHttpResponseInterceptor = function (n, t) { return { response: function (t) { return t.status === 401 && console.log("Response 401"), t || n.when(t) }, responseError: function (i) { return i.status === 401 && (console.log("Response Error 401", i), t.path("/login").search("returnUrl", t.path())), n.reject(i) } } }; AuthHttpResponseInterceptor.$inject = ["$q", "$location"]; LoginFactory = function (n, t) {
////    return function (i, r, u) {
////        var f = t.defer(); return n.post("/Account/Login", { Email: i, Password: r, RememberMe: u }).success(function (n) { n == "True" ? f.resolve({ success: !0 }) : f.resolve({ success: !1 }) }).error(function () { f.resolve({ success: !1 }) }), f.promise
////    }
////}; LoginFactory.$inject = ["$http", "$q"];

////RegistrationFactory = function (n, t) {
////    return function (i, r, u) {
////        var f = t.defer();
////        return n.post("/Account/Register", { Email: i, Password: r, ConfirmPassword: u })
////            .success(function (n) { n == "True" ? f.resolve({ success: !0 }) : f.resolve({ success: !1 }) })
////            .error(function () { f.resolve({ success: !1 }) }), f.promise
////    }
////}; RegistrationFactory.$inject = ["$http", "$q"]