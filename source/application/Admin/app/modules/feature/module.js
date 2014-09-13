'use strict';

var featureModule = angular.module('FeatureModule', []);

featureModule.config(['$routeProvider', function ($routeProvider) {
	$routeProvider.when('/feature', {
		templateUrl: 'feature/index.cshtml',
		controller: 'FeatureListController',
		resolve: {
			features: ['Features', function (Features) {
				//TODO: get only features current user is authorized
				return Features.all();
			}]
		}
	})
  .when('/feature/:featureId', {
  	templateUrl: 'edit.cshtml',
  	controller: 'FeatureEditController'
  })
  .when('/feature/add', {
  	templateUrl: 'add.cshtml',
  	controller: 'FeatureAddController'
  });
}]);

featureModule.factory('featureService', ['$http', function ($http) {
	return new FeatureService($http);
}]);

featureModule.factory('featureModel', ['featureService', function (featureService) {
	return new FeatureModel(featureService);
}]);