angular.module('app').controller('noteSearchCtrl', function ($scope, $location, $routeParams, notes) {
    $scope.vm = {};

    $scope.vm.noteList = notes.query();
});