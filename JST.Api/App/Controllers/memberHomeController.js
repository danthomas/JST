'use strict';

app.controller('memberHomeController', function ($scope, $location, workoutService) {

    $scope.weekBeginning = new Date();
    $scope.weekBeginning = new Date($scope.weekBeginning.getFullYear(), $scope.weekBeginning.getMonth(), $scope.weekBeginning.getDate());
    
    $scope.next = function () {
        $scope.weekBeginning = new Date($scope.weekBeginning.setDate(new Date($scope.weekBeginning).getDate() + 7));
        refresh();
    };

    $scope.prev = function () {
        $scope.weekBeginning = new Date($scope.weekBeginning.setDate(new Date($scope.weekBeginning).getDate() - 7));
        refresh();
    };

    $scope.viewWorkoutDay = function(date) {
        $location.url('/memberWorkoutDay/' + (date + '').substring(0, 10));
    };

    function refresh() {
        workoutService.homePageDetail($scope.weekBeginning, function (data) {
            $scope.weekBeginning = data.model.weekBeginning;
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});