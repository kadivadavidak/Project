angular.module('app')
	.config(['$httpProvider', function($httpProvider) {
			var loginInterceptor = [
				'$location', '$q', function($location, $q) {
					return {
						'response': function success(response) {
							return response;
						},
						'responseError': function error(response) {
							if (response.status === 401) {
								$location.path('/logon');
								return $q.reject(response);
							} else {
								return $q.reject(response);
							}
						}
					}
				}
			];
			$httpProvider.interceptors.push(loginInterceptor);
		}
	])