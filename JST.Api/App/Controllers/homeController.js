'use strict';

app.controller('homeController', function ($scope, globalData) {
    globalData.pageName = 'Home';
    $scope.model = { title: "xxx" };
});