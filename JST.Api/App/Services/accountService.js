app.factory('accountService', function ($http, globalData) {
    return {

        getAccounts: function (success, error) {
            $http({
                method: "post",
                url: "api/account/getAccounts",
                data: JSON.stringify({
                    sessionId: globalData.sessionId
                })
            }).success(function (data) {
                success(data);
            }).error(function () {
                error(data);
            });
        }
    };
});