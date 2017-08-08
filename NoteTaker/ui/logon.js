angular.module('app').controller('logonCtrl', function ($scope, $location, $rootScope, accounts, userState) {
	$scope.vm = $scope.vm || { 'username': '', 'password': '', 'error': null, 'loggedon': false };

	$scope.submit = function () {
		var data = { 'username': $scope.vm.username, 'password': $scope.vm.password };
		accounts.logon({ 'action': 'logon' }, data,
			function () {
				userState.username = $scope.vm.username;
				userState.loggedon = true;
				$location.url('/');
			},
			function (value) {
				$scope.vm.error = value;
			});
	};
});