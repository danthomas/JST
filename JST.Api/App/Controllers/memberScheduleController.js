'use strict';

app.controller('memberScheduleController', function ($scope, $location, workoutService, globalData) {

    globalData.pageName = "Competitors Schedule";

    if (!globalData.weekBeginning) {
        globalData.weekBeginning = new Date();
        globalData.weekBeginning = new Date(globalData.weekBeginning.getFullYear(), globalData.weekBeginning.getMonth(), globalData.weekBeginning.getDate());
    }

    $scope.weekBeginning = globalData.weekBeginning;

    $scope.next = function () {
        $scope.weekBeginning = globalData.weekBeginning = new Date(globalData.weekBeginning.setDate(new Date(globalData.weekBeginning).getDate() + 7));
        refresh();
    };

    $scope.prev = function () {
        $scope.weekBeginning = globalData.weekBeginning = new Date(globalData.weekBeginning.setDate(new Date(globalData.weekBeginning).getDate() - 7));
        refresh();
    };

    $scope.viewWorkoutDay = function(date) {
        $location.url('/memberWorkoutDay/' + (date + '').substring(0, 10));
    };

    function refresh() {
        workoutService.homePageDetail(globalData.weekBeginning, function (data) {
            $scope.weekBeginning = globalData.weekBeginning = data.model.weekBeginning;
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});