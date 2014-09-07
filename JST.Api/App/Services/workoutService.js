app.factory('workoutService', function (globalData, $http, $rootScope) {
    return {
        login: function (userName, password, result) {
            console.log('logging in as ' + userName);

            $http({
                method: "post",
                url: "api/account/login",
                data: {
                    AccountName: userName,
                    Password: password
                }
            }).success(function (data) {
                if (data.isSuccess) {
                    globalData.sessionId = data.model.sessionId;
                    globalData.displayName = data.model.displayName;
                    $rootScope.accountTypeCode = globalData.accountTypeCode = data.model.accountTypeCode;
                    console.log('login successful');
                } else {
                    globalData.sessionId = null;
                    globalData.displayName = null;
                    $rootScope.accountTypeCode = globalData.accountTypeCode = null;
                    console.log('login failed');
                }
                result(data.isSuccess);
            }).error(function () {
                globalData.sessionId = null;
                globalData.displayName = null;
                $rootScope.accountTypeCode = globalData.accountTypeCode = null;
                console.log('login failed');
            });
        },
        logout: function () {
            console.log('logging out');
            globalData.sessionId = null;
            globalData.displayName = '';
            globalData.accountTypeCode = '';
            $rootScope.accountTypeCode = globalData.accountTypeCode = null;
        }
    };
});