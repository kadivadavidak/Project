angular.module('app').service('userState', function (accounts) {
	var userState = { 'username': null, 'loggedon': false };
	accounts.lookup({},
		function(value) {
			userState.username = value.name;
			userState.loggedon = true;
		}, function () {
			userState.username = null;
			userState.loggedon = false;
		}
	);
	return userState;
});