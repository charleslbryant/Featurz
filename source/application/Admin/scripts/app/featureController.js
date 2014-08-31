angular.module('Featurz', [])
	.controller('FeatureController', function ($scope, $http) {
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
	});