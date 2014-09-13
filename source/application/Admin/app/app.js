'use strict';

angular.module('app', [
	'ngRoute',
	'dashboard',
  'features',
  'admin',
  'services.breadcrumbs',
  'services.i18nNotifications',
  'services.httpRequestTracker',
  'security',
  'directives.crud',
  'templates.app',
  'templates.common']);

//TODO: move those messages to a separate module


angular.module('app').config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
	$locationProvider.html5Mode(true);
	$routeProvider.otherwise({ redirectTo: '/dashboard' });
}]);

// Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
// can be injected here. This is to prevent further system configuration during application run time.
angular.module('app').run(['$templateCache', '$rootScope', '$state', '$stateParams', 'security', function ($templateCache, $rootScope, $state, $stateParams, security) {

	// <ui-view> contains a pre-rendered template for the current view
	// caching it will prevent a round-trip to a server at the first page load
	var view = angular.element('#ui-view');
	$templateCache.put(view.data('tmpl-url'), view.html());

	// Allows to retrieve UI Router state information from inside templates
	$rootScope.$state = $state;
	$rootScope.$stateParams = $stateParams;

	$rootScope.$on('$stateChangeSuccess', function (event, toState) {
		// Sets the layout name, which can be used to display different layouts (header, footer etc.)
		// based on which page the user is located
		$rootScope.layout = toState.layout;
	});

	// Get the current user when the application starts
	// (in case they are still logged in from a previous session)
	security.requestCurrentUser();
}]);