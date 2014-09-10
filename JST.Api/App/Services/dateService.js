app.factory('dateService', function (globalData) {

    function moveDays(date, days) {
        date = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        date = new Date(date.setTime(date.getTime() + days * 86400000));
        return date;
    }

    return {
        setDefaultDate: function () {
            if (!globalData.date) {
                globalData.date = new Date();
                globalData.date = new Date(globalData.date.getFullYear(), globalData.date.getMonth(), globalData.date.getDate());
            }
            return globalData.date;
        },
        setDate: function(date) {
            globalData.date = date;
            return globalData.date;
        },
        moveDate: function (noDays) {
            globalData.date = moveDays(globalData.date, noDays);
            return globalData.date;
        },


        moveWeekBeginning: function (noDays) {
            globalData.weekBeginning = moveDays(globalData.weekBeginning, noDays);
            return globalData.weekBeginning;
        }
    };
});