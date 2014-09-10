'use strict';

app.controller('memberWorkoutDayController', function ($scope, $routeParams, $location, globalData, workoutService, dateService) {

    globalData.pageName = 'Competitors Workout Day';

    if ($routeParams.date) {
        $scope.date = dateService.setDate(new Date($routeParams.date));
    } else {
        $scope.date = dateService.setDefaultDate();
    }
    
    $scope.save = function () {

        workoutService.saveResult(globalData.sessionId, $scope.resultId, $scope.workoutDateId, $scope.resultDetail, function (data) {
            if (data.isSuccess) {
                $scope.resultId = data.model;
                $location.url('/memberSchedule');
            }
        });
    };

    $scope.next = function () {
        $scope.date = dateService.moveDate(1);
        refresh();
    };

    $scope.prev = function () {
        $scope.date = dateService.moveDate(-1);
        refresh();
    };

    function refresh() {
        workoutService.memberWorkoutDayDetail(globalData.date, function (data) {
            $scope.date = dateService.setDate(new Date(data.model.date));
            $scope.workouts = data.model.workouts;
            $scope.resultId = data.model.resultId;
            $scope.workoutDateId = data.model.workoutDateId;
            $scope.resultDetail = data.model.resultDetail;
        });
    }

    refresh();

});