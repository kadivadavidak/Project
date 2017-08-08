angular.module('app').controller('noteDeleteCtrl', function ($scope, $location, $routeParams, notes) {
	$scope.vm = {	};

	$scope.vm = notes.get({id:$routeParams.noteId});

	$scope.delete = function() {
		$scope.vm.$delete();
		$location.url('/note');
	}
});