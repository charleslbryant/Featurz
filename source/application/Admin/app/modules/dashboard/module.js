'use strict';

angular.module('dashboard', ['resources.features'])

.config(['$routeProvider', function ($routeProvider) {
  $routeProvider.when('/dashboard', {
    templateUrl:'dashboard/index.cshtml',
    controller:'DashboardController',
    resolve:{
      features:['Features', function (Features) {
        //TODO: get only features current user is authorized
        return Features.all();
      }]
    }
  });
}])

