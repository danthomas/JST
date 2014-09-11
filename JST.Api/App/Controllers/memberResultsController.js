'use strict';

app.controller('memberResultsController', function ($scope, $location, workoutService, globalService) {

    globalService.setPageName('Competitor Results');
    
    $scope.date = globalService.getDate();

    $scope.next = function () {
        globalService.moveDate(1);
        refresh('next');
    };

    $scope.prev = function () {
        globalService.moveDate(-1);
        refresh('prev');
    };

    function refresh(direction) {
        workoutService.memberResultsDetail(globalService.getDate(), direction, function (data) {
            $scope.date = globalService.setDate(new Date(data.model.date));
            $scope.workouts = data.model.workouts;
            $scope.results = data.model.results;
        });
    }

    refresh();

});