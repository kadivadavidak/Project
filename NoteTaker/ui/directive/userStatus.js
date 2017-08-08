angular.module('app').directive('userStatus', function () {
	return {
		restrict: 'E,A',
		replace: true,
		templateUrl: '/ui/directive/userstatus.html',
		controller:'userStatusCtrl',
		scope: {}
	};
});

angular.module('app').controller('userStatusCtrl', function($scope, userState) {
	$scope.vm = userState;
});