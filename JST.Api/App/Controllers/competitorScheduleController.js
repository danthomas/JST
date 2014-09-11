'use strict';

app.controller('competitorScheduleController', function ($scope, workoutService, globalService) {

    globalService.setPageName('Competitor - Schedule');

    $scope.weekBeginning = globalService.getWeekBeginning();

    $scope.edit = function (workoutDay) {
        if (!workoutDay.isRestDay) {
            globalService.setDate(new Date(workoutDay.date));
            globalService.url('/competitorWorkoutDay', true);
        }
    };

    $scope.next = function () {
        $scope.weekBeginning = globalService.moveWeekBeginning(7);
        refresh();
    };

    $scope.prev = function () {
        $scope.weekBeginning = globalService.moveWeekBeginning(-7);
        refresh();
    };

    $scope.rowClick = function (workoutDay) {
        globalService.setDate(new Date(workoutDay.date));
        if (!workoutDay.isRestDay) {
            globalService.url('/competitorResults');
        }
    };

    $scope.resultCellClick = function (workoutDay) {
        if (!workoutDay.isRestDay) {
            globalService.setDate(new Date(workoutDay.date));
            globalService.url('/competitorWorkoutDay', true);
        }
    };

    function refresh() {
        workoutService.competitorScheduleDetail(globalService.getWeekBeginning(), function (data) {
            $scope.weekBeginning = globalService.setWeekBeginning(new Date(data.model.weekBeginning));
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});