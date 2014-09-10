﻿'use strict';

angular.module('featurz.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Dashboard';
        $scope.$on('$viewContentLoaded', function () {
        });
    }])

    // Path: /feature
    .controller('FeatureCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
    	$scope.$root.title = 'Features';
    	$scope.name = "";
    	$scope.userId = "";
    	$scope.ticket = "";
    	$scope.isActive = false;
    	$scope.isEnabled = false;
    	$scope.strategyId = "";
    	$scope.result = "";

    	$scope.addFeature = function (feature) {
    		$http.post('/api/feature', {
    			'name': feature.name,
    			'userId': feature.userId,
    			'ticket': feature.ticket,
    			'isActive': feature.isActive,
    			'isEnabled': feature.isEnabled,
    			'strategyId': feature.strategyId
    		})
					.success(function (data, status, headers, config) {
						$scope.result = "Feature added.";
					})
					.error(function (data, status, headers, config) {
						$scope.result = "Uh Oh! I made a boo boo.";
					});
    	};

      $scope.$on('$viewContentLoaded', function () {
      });
    }])

    // Path: /featureAdd
    .controller('FeatureAddCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
    	$scope.$root.title = 'Add Feature';
    	$scope.feature = {}
    	$scope.addFeature = function () {
    		$http.post('process.php', $scope.formData)
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
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | Sign In';
        // TODO: Authorize a user
        $scope.login = function () {
            $location.path('/');
            return false;
        };
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
        });
    }]);