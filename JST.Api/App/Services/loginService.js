app.factory('loginService', function (globalData, globalService, $http) {
    return {
        login: function (userName, password, success, error) {

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
                    globalData.routes = data.model.routes;
                } else {
                    globalData.sessionId = null;
                    globalData.displayName = null;
                    globalData.roleCodes = null;
                    globalData.routes = null;
                }
                success(data.isSuccess);
            }).error(function () {
                globalData.sessionId = null;
                globalData.displayName = null;
                globalData.roleCodes = null;
                globalData.routes = null;
                error();
            });
        },
        logout: function () {
            globalService.clear();
        }
    };
});