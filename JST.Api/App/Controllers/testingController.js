app.controller('testingController', function ($scope) {
    $scope.testDate = new Date();
    $scope.testDate = new Date($scope.testDate.getFullYear(), $scope.testDate.getMonth(), $scope.testDate.getDate());

    $scope.noDays = 1;
    $scope.SubtractDays = function () {
        console.log('subtracting ' + $scope.noDays + ' days from ' + $scope.testDate);
        $scope.testDate = moveDays($scope.testDate, -$scope.noDays);
        console.log($scope.testDate);
    };
    $scope.AddDays = function () {
        console.log('adding ' + $scope.noDays + ' days to ' + $scope.testDate);
        $scope.testDate = moveDays($scope.testDate, $scope.noDays);
        console.log($scope.testDate);
    };


    function moveDays(date, days) {
        date = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        date = new Date(date.setTime(date.getTime() + days * 86400000));
        return date;
    }

});