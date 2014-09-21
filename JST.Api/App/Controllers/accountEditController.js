'use strict';

app.controller('accountEditController', function ($scope, $routeParams, $location, globalData, accountService) {
    globalData.pageName = 'Accounts';

    $scope.selectedAccounts = [];

    if ($routeParams.accountId) {
        accountService.getAccountEdit($routeParams.accountId, function(data) {
            $scope.account = data.model;
        });
    } else {
        $scope.account = {
            accountId: 0,
            accountName: '',
            displayName: ''
        };
    }

    $scope.save = function () {
        accountService.saveAccount($scope.account, function (data) {
            if (data.isSuccess) {
                $location.url('/accountList');
            } else {
                
            }
        });
    };

    $scope.cancel = function () {
        $location.url('/accountList');
    };
});