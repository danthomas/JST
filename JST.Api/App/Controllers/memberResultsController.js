'use strict';

app.controller('memberResultsController', function ($scope, $location, workoutService, globalData, dateService) {

    globalData.pageName = "Competitors Results";
    
    $scope.date = dateService.setDefaultDate();

    $scope.next = function () {
        $scope.date = dateService.moveDate(1);
        refresh();
    };

    $scope.prev = function () {
        $scope.date = dateService.moveDate(-1);
        refresh();
    };

    function refresh() {
        workoutService.memberResultsDetail(globalData.date, function (data) {
            $scope.results = data.model.results;
        });
    }

    refresh();

});