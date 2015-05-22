var LinksFactory = function ($http, $q) {
    var factory = {};
    factory.retrieve = function () {
        return $http.get('Places/GetAllLinks');

    };
    return factory;
}

LinksFactory.$inject = ['$http', '$q'];