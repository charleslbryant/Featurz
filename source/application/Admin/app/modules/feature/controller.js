'use strict';

var featureController = angular.module('FeatureModule', []);

// Path: /feature/add
featureController.controller('FeatureAddController', ['$scope', '$location', '$window', function ($scope, $location, $window) {
	$scope.$root.title = 'Add Feature';
	$scope.feature = {};
	$scope.name = "";
	$scope.userId = "";
	$scope.ticket = "";
	$scope.isActive = false;
	$scope.isEnabled = false;
	$scope.strategyId = "";
	$scope.result = "";

	$scope.featureAdd = function () {
		$http.post('featurz/api/feature/add', $scope.formData)
		.success(function (data) {
			console.log(data);

			if (!data.success) {
				// if not successful, bind errors to error variables
				$scope.errorName = data.errors.name;
				$scope.errorSuperhero = data.errors.superheroAlias;
			} else {
				// if successful, bind success message to message
				$scope.message = data.message;
			}
		});
	};

	$scope.$on('$viewContentLoaded', function () {
	});
}]);

// Path: /feature/list
featureController.controller('FeatureListController', ['$scope', '$location', '$window', function ($scope, $location, $window) {
	$scope.$root.title = 'Add Feature';
	$scope.feature = {};

	$scope.featureAdd = function () {
		$http.post('featurz/api/feature/add', $scope.formData)
		.success(function (data) {
			console.log(data);

			if (!data.success) {
				// if not successful, bind errors to error variables
				$scope.errorName = data.errors.name;
				$scope.errorSuperhero = data.errors.superheroAlias;
			} else {
				// if successful, bind success message to message
				$scope.message = data.message;
			}
		});
	};

	$scope.$on('$viewContentLoaded', function () {
	});
}]);