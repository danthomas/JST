app.factory('accountService', function ($http, globalData) {
    return {
        getAccountList: function(success, error) {
            $http({
                method: "post",
                url: "api/account/getAccountList",
                data: JSON.stringify({
                    sessionId: globalData.sessionId
                })
            }).success(function(data) {
                success(data);
            }).error(function() {
                error(data);
            });
        },

        getAccountEdit: function(accountId, success, error) {
            $http({
                method: "post",
                url: "api/account/getAccountEdit",
                data: JSON.stringify({
                    sessionId: globalData.sessionId,
                    accountId: accountId
                })
            }).success(function (data) {
                success(data);
            }).error(function () {
                error(data);
            });
        },

        saveAccount: function (account, success, error) {
            $http({
                method: "post",
                url: "api/account/saveAccount",
                data: JSON.stringify({
                    sessionId: globalData.sessionId,
                    accountId: account.accountId,
                    accountName: account.accountName,
                    displayName: account.displayName
                })
            }).success(function (data) {
                success(data);
            }).error(function () {
                error(data);
            });
        }
};
});