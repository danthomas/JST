'use strict';

app.controller('trainerScheduleController', function ($scope, workoutService, globalService) {

    globalService.setPageName('Schedule');

    $scope.weekBeginning = globalService.getWeekBeginning();

    $scope.save = function () {
        $scope.message = '';

        workoutService.saveTrainerSchedule($scope.workoutDays, function(data) {
            if (data.isSuccess) {
                refresh();
            }
        },function() {
            
        });
    };

    $scope.next = function () {
        $scope.message = '';
        $scope.weekBeginning = globalService.moveWeekBeginning(7);
        refresh();
    };

    $scope.prev = function () {
        $scope.message = '';
        $scope.weekBeginning = globalService.moveWeekBeginning(-7);
        refresh();
    };

    function refresh() {
        workoutService.trainerScheduleDetail(globalService.getWeekBeginning(), function (data) {
            $scope.weekBeginning = globalService.setWeekBeginning(new Date(data.model.weekBeginning));
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});