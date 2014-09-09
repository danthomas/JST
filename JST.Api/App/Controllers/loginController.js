﻿'use strict';

app.controller('loginController', function ($scope, $location, globalData, loginService) {
    globalData.pageName = 'Login';

    $scope.credentials = { userName: 'passantc', password: 'burpee' };
    $scope.success = true;

    $scope.login = function (loginForm, credentials) {

        if (loginForm.$valid) {

            loginService.login(credentials.userName, credentials.password, function (isSuccess, message) {
                $scope.success = isSuccess;
                if (isSuccess) {
                    if (globalData.accountTypeCode == "Admin") {
                        $location.url('/adminHome');
                    }
                    else if (globalData.accountTypeCode == "Member") {
                        $location.url('/memberSchedule');
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