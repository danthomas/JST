'use strict';

app.controller('memberScheduleController', function ($scope, workoutService, globalService) {

    globalService.setPageName('Competitor Schedule');

    $scope.weekBeginning = globalService.getWeekBeginning();

    $scope.next = function () {
        $scope.weekBeginning = globalService.moveWeekBeginning(7);
        refresh();
    };

    $scope.prev = function () {
        $scope.weekBeginning = globalService.moveWeekBeginning(-7);
        refresh();
    };

    $scope.viewWorkoutDay = function (workoutDay) {
        globalService.setDate(new Date(workoutDay.date));
        if (!workoutDay.isRestDay) {
            globalService.url('/memberWorkoutDay');
        }
    };

    function refresh() {
        workoutService.homePageDetail(globalService.getWeekBeginning(), function (data) {
            $scope.weekBeginning = globalService.setWeekBeginning(new Date(data.model.weekBeginning));
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});