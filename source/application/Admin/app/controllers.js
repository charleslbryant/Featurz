'use strict';

var appController = angular.module('app', []);

// Path: /
appController.controller('HomeController', ['$scope', '$location', '$window', function ($scope, $location, $window) {
      $scope.$root.title = 'Dashboard';
      $scope.$on('$viewContentLoaded', function () {
      });
  }])

// Path: /error/404
appController.controller('Error404Controller', ['$scope', '$location', '$window', function ($scope, $location, $window) {
      $scope.$root.title = 'Page Not Found';
      $scope.$on('$viewContentLoaded', function () {
      });
}]);

appController.controller('AppController', ['$scope', 'i18nNotifications', 'localizedMessages', function ($scope, i18nNotifications, localizedMessages) {

	$scope.notifications = i18nNotifications;

	$scope.removeNotification = function (notification) {
		i18nNotifications.remove(notification);
	};

	$scope.$on('$routeChangeError', function (event, current, previous, rejection) {
		i18nNotifications.pushForCurrentRoute('errors.route.changeError', 'error', {}, { rejection: rejection });
	});
}]);

appController.controller('HeaderController', ['$scope', '$location', '$route', 'security', 'breadcrumbs', 'notifications', 'httpRequestTracker',
  function ($scope, $location, $route, security, breadcrumbs, notifications, httpRequestTracker) {
  	$scope.location = $location;
  	$scope.breadcrumbs = breadcrumbs;

  	$scope.isAuthenticated = security.isAuthenticated;
  	$scope.isAdmin = security.isAdmin;

  	$scope.home = function () {
  		if (security.isAuthenticated()) {
  			$location.path('/dashboard');
  		} else {
  			$location.path('/projectsinfo');
  		}
  	};

  	$scope.isNavbarActive = function (navBarPath) {
  		return navBarPath === breadcrumbs.getFirst().name;
  	};

  	$scope.hasPendingRequests = function () {
  		return httpRequestTracker.hasPendingRequests();
  	};
  }]);