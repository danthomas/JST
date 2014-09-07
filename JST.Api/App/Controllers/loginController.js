'use strict';

app.controller('loginController', function ($scope, $location, globalData, loginService) {
    globalData.pageName = 'Login';

    $scope.credentials = { userName: '', password: '' };

    $scope.login = function (loginForm, credentials) {

        if (loginForm.$valid) {
            loginService.login(credentials.userName, credentials.password, function (isSuccess, message) {
                if (isSuccess) {
                    if (globalData.accountTypeCode == "Admin") {
                        $location.url('/adminHome');
                    }
                    else if (globalData.accountTypeCode == "Member") {
                        $location.url('/memberHome');
                    }
                    else if (globalData.accountTypeCode == "Trainer") {
                        $location.url('/trainerHome');
                    }
                } else {

                }
            });
        }
    };
});