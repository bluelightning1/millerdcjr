var PlacesController = function ($scope, $http, LinksFactory) {
    $scope.load = function () {
        $http.get('/Places/GetAllLinks')
       .success(function (data) {
           $scope.links = data;
       })
       .error(function (data) {
           $scope.links = data;
       });
    }
}

PlacesController.$inject = ['$scope', '$http', 'LinksFactory'];