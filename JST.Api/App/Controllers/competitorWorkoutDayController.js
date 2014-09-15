'use strict';

app.controller('competitorWorkoutDayController', function ($scope, workoutService, globalService) {

    globalService.setPageName('Competitor - Workout Day');

    $scope.date = globalService.getDate();

    $scope.save = function () {

        workoutService.saveResult($scope.resultId, $scope.workoutDateId, $scope.resultDetail, function (data) {
            if (data.isSuccess) {
                $scope.resultId = data.model;
                globalService.backUrl('/competitorResults');
            }
        });
    };

//    $scope.next = function () {
//        globalService.moveDate(1);
//        refresh('next');
//    };
//
//    $scope.prev = function () {
//        globalService.moveDate(-1);
//        refresh('prev');
//    };

    function refresh(direction) {
        workoutService.competitorWorkoutDayDetail(globalService.getDate(), direction, function (data) {
            $scope.date = globalService.setDate(new Date(data.model.date));
            $scope.comment = data.model.comment;
            $scope.workouts = data.model.workouts;
            $scope.resultId = data.model.resultId;
            $scope.workoutDateId = data.model.workoutDateId;
            $scope.resultDetail = data.model.resultDetail;
        });
    }

    refresh('none');

});