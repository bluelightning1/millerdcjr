var LoginController = function ($scope, $routeParams, $location,LoginFactory) {
    $scope.loginForm = {
        emailAddress: '',
        password: '',
        rememberMe: false,
        returnUrl: $routeParams.returnUrl,
        loginFailure: false
    };

    $scope.login = function () {

        var results = LoginFactory($scope.loginForm.emailAddress, $scope.loginForm.password, $scope.loginForm.rememberMe);

        results.then(function (result) {
            if (result.success) {
                if ($scope.loginForm.returnUrl !== undefined) {
                    alert("success, but return url !== undefined");
                    $location.path('/routeOne');
                } else {
                    alert("succes, but no return url");
                    $location.path($scope.loginForm.returnUrl);
                }
            } else {
                $scope.loginForm.loginFailure = true;
            }
        });

    }
}

LoginController.$inject = ['$scope', '$routeParams', '$location', 'LoginFactory'];//, LoginFactory, 'LoginFactory'