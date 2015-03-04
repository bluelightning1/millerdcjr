var LinksFactory = function ($http, $q) {
    return function () {
        var deferredObject = $q.defer();
        $http.get('/api/Links')
               .success(function (data) {
                   if (data == "True") {
                       deferredObject.resolve({ success: true });
                   } else {
                       deferredObject.resolve({ success: false });
                   }
               })
               .error(function (data) {
                   deferredObject.resolve({ success: false });
               });

        return deferredObject.promise;
    }
}

LinksFactory.$inject = ['$http', '$q'];