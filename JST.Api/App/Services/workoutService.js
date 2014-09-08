app.factory('workoutService', function ($http) {
    return {
        homePageDetail: function (date, result) {
            $http({
                method: "post",
                url: "api/workout/homepagedetail",
                data: '"' + date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate() + 'T00:00:00.000Z"'
            }).success(function (data) {
                data.model.weekBeginning = new Date(data.model.weekBeginning);
                result(data);
            }).error(function () {
            });
        }
    };
});