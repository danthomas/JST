'use strict';

app.controller('accountController', function ($scope, globalData, accountService) {
    globalData.pageName = 'Accounts';

    $scope.selectedAccounts = [];

    accountService.getAccounts(function (data) {
        $scope.accounts = data.model;
    });

    $scope.rowClick = function (account) {
        $scope.selectedAccounts = [account];
    };

    $scope.edit = function () {

    };
});