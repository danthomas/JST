'use strict';

app.controller('accountListController', function ($scope, $location, globalData, accountService) {
    globalData.pageName = 'Accounts';

    $scope.selectedAccounts = [];

    accountService.getAccountList(function (data) {
        $scope.accounts = data.model;
    });

    $scope.rowClick = function (account) {
        $scope.selectedAccounts = [account];
    };

    $scope.add = function () {
        $location.url('/accountEdit');
    };

    $scope.edit = function (account) {
        $location.url('/accountEdit/' + account.accountId);
    };
});