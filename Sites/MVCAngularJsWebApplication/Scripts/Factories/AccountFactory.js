﻿var AccountFactory = function ($http, $q) {
    return function (emailAddress, password) {

        var deferredObject = $q.defer();

        $http.post(
            '/Account/Login', {
                Email: emailAddress,
                Password: password
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

AccountFactory.$inject = ['$http', '$q'];