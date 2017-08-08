angular.module('app').controller('noteDetailCtrl', function ($scope, $location, $routeParams, notes) {
	$scope.vm = {	};

	$scope.vm = notes.get({id:$routeParams.noteId});
});