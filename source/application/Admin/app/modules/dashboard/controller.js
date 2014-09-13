'use strict';

var dashboardController = angular.module('dashboard', ['resources.features']);

dashboardController.controller('DashboardController', ['$scope', '$location', 'features', function ($scope, $location, features) {
	$scope.features = features;

	$scope.addFeature = function () {
		$location.path('/feature/add');
	};

	$scope.editFeature = function (featureId) {
		$location.path('/feature/' + featureId);
	};
}]);