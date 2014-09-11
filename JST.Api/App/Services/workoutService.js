app.factory('workoutService', function ($http, globalData) {
    return {
        competitorScheduleDetail: function (date, result) {
            $http({
                method: "post",
                url: "api/workout/competitorScheduleDetail",
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


        competitorWorkoutDayDetail: function (date, direction, result) {
            $http({
                method: "post",
                url: "api/workout/competitorWorkoutDayDetail",
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


        competitorResultsDetail: function (date, direction, result) {
            $http({
                method: "post",
                url: "api/workout/competitorResultsDetail",
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


        competitorMyResultsDetail: function (date, direction, result) {
            $http({
                method: "post",
                url: "api/workout/competitorMyResultsDetail",
                data: JSON.stringify({
                    sessionId: globalData.sessionId
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