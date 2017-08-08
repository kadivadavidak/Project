angular.module('app').controller('logoutCtrl', function ($scope, userState, accounts) {
	accounts.logout({ 'action': 'logout' });
	userState.loggedon = false;
	userState.username = null;
});