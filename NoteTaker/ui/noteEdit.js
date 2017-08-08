angular.module('app').controller('noteEditCtrl', function ($scope, $location, $routeParams, notes) {
	$scope.vm = {};

	$scope.vm = notes.get({id:$routeParams.noteId});
	$scope.save = function() {
		notes.update({}, $scope.vm, function() {
			$location.url('/note');
		});
	};
});