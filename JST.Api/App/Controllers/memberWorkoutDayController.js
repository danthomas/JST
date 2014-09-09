'use strict';

app.controller('memberWorkoutDayController', function ($scope, $routeParams, $location, globalData, workoutService) {

    globalData.pageName = 'Competitors Workout Day';

    $scope.save = function () {

        workoutService.saveResult(globalData.sessionId, $scope.resultId, $scope.workoutDateId, $scope.resultDetail, function (data) {
            if (data.isSuccess) {
                $scope.resultId = data.model;
                $location.url('/memberHome');
            }
        });
    };

    $scope.cancel = function () {
        $location.url('/memberHome');
    };

    function refresh() {
        workoutService.memberWorkoutDayDetail(new Date($routeParams.date), function (data) {
            $scope.date = data.model.date;
            $scope.workouts = data.model.workouts;
            $scope.resultId = data.model.resultId;
            $scope.workoutDateId = data.model.workoutDateId;
            $scope.resultDetail = data.model.resultDetail;
        });
    }

    refresh();

});