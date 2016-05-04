var openWifiApp = angular.module('openWifiApp', ['ngRoute', 'ZoneControllers']);

openWifiApp.config(['$routeProvider', function($routeProvider) {
  $routeProvider.
  when('/list', {
    templateUrl: 'partials/list.html',
    controller: 'ListController'
  }).
  when('/details/:zoneID', {
    templateUrl: 'partials/details.html',
    controller: 'DetailsController'
  }).
  otherwise({
    redirectTo: '/list'
  });
}]);

var ZoneControllers = angular.module("ZoneControllers", []);

ZoneControllers.controller("ListController", ['$scope', '$http',
  function($scope, $http) {
    $http.get('js/pracas.json').success(function(data) {
      $scope.zoneItem = data;
      $scope.getLen = function() {
        return $scope.data.zone.length;
      };
    });
  }
]);

ZoneControllers.controller("DetailsController", ['$scope', '$http', '$routeParams',
  function($scope, $http, $routeParams) {
    $http.get('js/pracas.json').success(function(data) {
      $scope.zoneItem = data;
      $scope.currentZone = $routeParams.zoneID;
    });
  }
]);
