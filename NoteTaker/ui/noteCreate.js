angular.module('app').controller('noteCreateCtrl', function ($scope, $location, $routeParams, notes) {
	$scope.vm = {	};

	$scope.save = function() {
		notes.save({}, $scope.vm, function() {
			$location.url('/note');
		});
	}
});