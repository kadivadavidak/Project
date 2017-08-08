angular.module('app').factory('notes', ['$resource', function ($resource) {
	return $resource('/api/v1/notes/:id', { id: '@id' },
	 {'update': { method:'PUT' }});
}]);