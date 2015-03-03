var LandingPageController = function($scope) {
    $scope.models = {
        helloAngular: 'I work!'
    };
}
// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
LandingPageController.$inject = ['$scope'];
//honecatControllers.controller('PhoneListCtrl', ['$scope', '$http',
//  function ($scope, $http) {
//      $http.get('phones/phones.json').success(function (data) {
//          $scope.phones = data;
//      });

//      $scope.orderProp = 'age';
//  }]);

//phonecatControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams',
//  function ($scope, $routeParams) {
//      $scope.phoneId = $routeParams.phoneId;
//  }]);


//angular.module('MVCAngularJsWebApplication', [])
//.controller('LandingPageController', ['$scope', function ($scope) {
//    $scope.models = {
//        helloAngular: 'I Work!'
//    };
//}]);