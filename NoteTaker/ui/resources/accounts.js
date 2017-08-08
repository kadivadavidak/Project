angular.module('app').factory('accounts', function ($resource) {
	return $resource('/api/v1/accounts/:action/:id', { id: '@id' }, {
		'logon': { 'method': 'POST' },
		'logout': { 'method': 'GET' },
		'lookup': { 'method': 'GET' }
	});
});