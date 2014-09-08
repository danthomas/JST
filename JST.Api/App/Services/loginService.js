app.factory('loginService', function (globalData, $http) {
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
                    globalData.accountTypeCode = data.model.accountTypeCode;
                    console.log('login successful');
                } else {
                    globalData.sessionId = null;
                    globalData.displayName = null;
                    globalData.accountTypeCode = null;
                    console.log('login failed');
                }
                result(data.isSuccess);
            }).error(function () {
                globalData.sessionId = null;
                globalData.displayName = null;
                globalData.accountTypeCode = null;
                console.log('login failed');
            });
        },
        logout: function () {
            console.log('logging out');
            globalData.sessionId = null;
            globalData.displayName = null;
            globalData.accountTypeCode = null;
        }
    };
});