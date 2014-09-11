app.factory('loginService', function (globalData, globalService, $http) {
    return {
        login: function (userName, password, success, error) {
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
                    globalData.roleCodes = data.model.roleCodes;
                    console.log('login successful');
                } else {
                    globalData.sessionId = null;
                    globalData.displayName = null;
                    globalData.roleCodes = null;
                    console.log('login failed');
                }
                success(data.isSuccess);
            }).error(function () {
                globalData.sessionId = null;
                globalData.displayName = null;
                globalData.roleCodes = null;
                console.log('login failed');
                error();
            });
        },
        logout: function () {
            console.log('logging out');
            globalService.clear();
        }
    };
});