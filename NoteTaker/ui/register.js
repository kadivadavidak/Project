angular.module('app').controller('registerCtrl', function($scope, $location, accounts) {
	$scope.vm = {};
	$scope.register = function () {
		accounts.save({ "action": "save" }, $scope.vm,
			function() {
				$location.url('/');
			},
			function(err) {
				$scope.vm.error = err.data.error;
			});
	}
});