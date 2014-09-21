'use strict';

app.controller('loginController', function ($scope, $location, globalData, loginService, globalService) {
    globalData.pageName = 'Login';

    $scope.credentials = { userName: 'fawcetts', password: 'squat' };
    $scope.success = true;
    $scope.message = "";

    $scope.login = function (loginForm, credentials) {

        if (loginForm.$valid) {

            loginService.login(credentials.userName, credentials.password, function (isSuccess, message) {
                //success
                $scope.success = isSuccess;
                if (isSuccess) {

                    globalService.landing();

                } else {
                    $scope.message = 'Login Failed.';
                }
            }, function() {
                //error
                $scope.message = 'Unable to Login at this time.';
            });
        }
    };
});