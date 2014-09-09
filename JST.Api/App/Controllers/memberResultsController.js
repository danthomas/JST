'use strict';

app.controller('memberResultsController', function ($scope, $location, workoutService, globalData) {

    globalData.pageName = "Competitors Results";

    if (!globalData.resultsDate) {
        globalData.resultsDate = new Date();
        globalData.resultsDate = new Date(globalData.resultsDate.getFullYear(), globalData.resultsDate.getMonth(), globalData.resultsDate.getDate());
    }
    $scope.resultsDate = globalData.resultsDate;

    $scope.next = function () {
        $scope.resultsDate = globalData.resultsDate = new Date(globalData.resultsDate.setDate(new Date(globalData.resultsDate).getDate() + 1));
        refresh();
    };

    $scope.prev = function () {
        $scope.resultsDate = globalData.resultsDate = new Date(globalData.resultsDate.setDate(new Date(globalData.resultsDate).getDate() - 1));
        refresh();
    };

    function refresh() {
        workoutService.memberResultsDetail(globalData.resultsDate, function (data) {
            $scope.results = data.model.results;
        });
    }

    refresh();

});