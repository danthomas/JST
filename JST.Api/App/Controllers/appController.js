'use strict';

app.controller('appController', function ($scope, $location, globalData, loginService) {

    $scope.$on('$locationChangeStart', function (event, next) {
        console.log('location changing to ' + next);

        //if user not logged in redirect to /login
        if ($location.path() != '/login' && globalData.sessionId == null) {
            $location.path("/login");
        }
    });

    $scope.logout = function () {
        loginService.logout();
        $location.path("/login");
    };

    $scope.redirect = function (path) {
        console.log('redirect to ' + path);
        $location.url(path);
    };

    $scope.global = globalData;

});