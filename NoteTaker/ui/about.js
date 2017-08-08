angular.module('app')
	.controller('aboutCtrl', function ($scope) {
		$scope.copyrightYear = new Date().getFullYear();
	});