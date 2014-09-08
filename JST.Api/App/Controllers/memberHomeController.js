'use strict';

app.controller('memberHomeController', function ($scope, workoutService) {

    $scope.weekBeginning = new Date();
    $scope.weekBeginning = new Date($scope.weekBeginning.getFullYear(), $scope.weekBeginning.getMonth(), $scope.weekBeginning.getDate());
    
    $scope.next = function () {
        console.log('next' + $scope.weekBeginning);
        $scope.weekBeginning = new Date($scope.weekBeginning.setDate(new Date($scope.weekBeginning).getDate() + 7));
        console.log('next' + $scope.weekBeginning);
        refresh();
    };

    $scope.prev = function () {
        $scope.weekBeginning = new Date($scope.weekBeginning.setDate(new Date($scope.weekBeginning).getDate() - 7));
        refresh();
    };

    function refresh() {
        console.log($scope.weekBeginning);
        console.log(new Date($scope.weekBeginning.getFullYear(), $scope.weekBeginning.getMonth(), $scope.weekBeginning.getDate()));

        workoutService.homePageDetail($scope.weekBeginning, function (data) {
            $scope.weekBeginning = data.model.weekBeginning;
            $scope.workoutTypes = data.model.workoutTypes;
            $scope.workoutDays = data.model.workoutDays;
        });
    }

    refresh();

});