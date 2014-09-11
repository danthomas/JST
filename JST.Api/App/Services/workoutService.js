app.factory('workoutService', function ($http, globalData) {
    return {
        homePageDetail: function (date, result) {
            $http({
                method: "post",
                url: "api/workout/homepageDetail",
                data: JSON.stringify({
                    sessionId: globalData.sessionId,
                    date: date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate()
                })
            }).success(function (data) {
                data.model.weekBeginning = new Date(data.model.weekBeginning);
                result(data);
            }).error(function () {
            });
        },


        memberWorkoutDayDetail: function (date, direction, result) {
            $http({
                method: "post",
                url: "api/workout/memberWorkoutDayDetail",
                data: JSON.stringify( {
                    sessionId: globalData.sessionId,
                    direction: direction,
                    date: date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate()
                })
            }).success(function (data) {
                result(data);
            }).error(function () {
            });
        },


        memberResultsDetail: function (date, direction, result) {
            $http({
                method: "post",
                url: "api/workout/memberResultsDetail",
                data: JSON.stringify({
                    sessionId: globalData.sessionId,
                    direction: direction,
                    date: date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate()
                })
            }).success(function (data) {
                result(data);
            }).error(function () {
            });
        },

        saveResult: function(resultId, workoutDateId, resultDetail, result) {

            $http({
                method: "post",
                url: "api/workout/saveResult",
                data: JSON.stringify({
                    sessionId: globalData.sessionId,
                    resultId: resultId,
                    workoutDateId: workoutDateId,
                    resultDetail: resultDetail
                })
            }).success(function (data) {
                result(data);
            }).error(function () {
            });
            

        }
    };
});