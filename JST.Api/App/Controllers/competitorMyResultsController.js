'use strict';

app.controller('competitorMyResultsController', function ($scope, $location, workoutService, globalService) {

    globalService.setPageName('Competitor - My Results');


    $scope.edit = function (workoutDay) {
        globalService.setDate(new Date(workoutDay.date));
        globalService.url('/competitorWorkoutDay', true, true);
    };

    $scope.rowClick = function (workoutDay) {
        globalService.setDate(new Date(workoutDay.date));
        globalService.url('/competitorResults');
    };

    function refresh(direction) {
        workoutService.competitorMyResultsDetail(globalService.getDate(), direction, function (data) {
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});