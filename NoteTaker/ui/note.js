angular.module('app').controller('noteCtrl', function ($scope, $location, notes) {
	$scope.vm = {	};

	$scope.vm.noteList = notes.query();

});