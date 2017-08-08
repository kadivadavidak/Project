var app = angular.module('app', ['ngResource', 'ngRoute'])
	.config(function($routeProvider, $locationProvider) {
		$routeProvider.when('/register', { templateUrl: '/ui/register.html', controller: "registerCtrl" });
		$routeProvider.when('/logon', { templateUrl: '/ui/logon.html', controller: "logonCtrl" });
		$routeProvider.when('/note', { templateUrl: '/ui/note.html', controller: "noteCtrl" });
		$routeProvider.when('/note/create', { templateUrl: '/ui/noteCreate.html', controller: "noteCreateCtrl" });
		$routeProvider.when('/note/edit/:noteId', { templateUrl: '/ui/noteEdit.html', controller: "noteEditCtrl" });
		$routeProvider.when('/note/detail/:noteId', { templateUrl: '/ui/noteDetail.html', controller: "noteDetailCtrl" });
		$routeProvider.when('/note/delete/:noteId', { templateUrl: '/ui/noteDelete.html', controller: "noteDeleteCtrl" });
		$routeProvider.when('/about', { templateUrl: '/ui/about.html', controller: "aboutCtrl" });
		$routeProvider.when('/logout', { templateUrl: '/ui/logout.html', controller: "logoutCtrl" });
		$routeProvider.otherwise({ redirectTo: '/about' });

		$locationProvider.html5Mode(true);
	});