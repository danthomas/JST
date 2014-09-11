app.factory('globalService', function (globalData, $location) {

    function moveDays(date, days) {
        date = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        date = new Date(date.setTime(date.getTime() + days * 86400000));
        return date;
    }

    return {

        url: function (url) {
            globalData.lastUrl = $location.$$path;
            $location.url(url);
        },
        
        lastUrl: function (otherwiseUrl) {
            if (globalData.lastUrl) {
                $location.url(globalData.lastUrl);
                globalData.lastUrl = null;
            } else {
                $location.url(otherwiseUrl);
            }

        },

        setPageName: function (pageName) {
            globalData.pageName = pageName;
        },

        getDate: function () {
            if (!globalData.date) {
                globalData.date = new Date();
                globalData.date = new Date(globalData.date.getFullYear(), globalData.date.getMonth(), globalData.date.getDate());
            }

            return globalData.date;
        },

        setDate: function (date) {
            globalData.date = date;
            return globalData.date;
        },

        moveDate: function (noDays) {
            globalData.date = moveDays(globalData.date, noDays);
            return globalData.date;
        },

        getWeekBeginning: function () {
            if (!globalData.weekBeginning) {
                globalData.weekBeginning = new Date();
                globalData.weekBeginning = new Date(globalData.weekBeginning.getFullYear(), globalData.weekBeginning.getMonth(), globalData.weekBeginning.getDate());
            }

            return globalData.weekBeginning;
        },

        setWeekBeginning: function (weekBeginning) {
            globalData.weekBeginning = weekBeginning;
            return globalData.weekBeginning;
        },

        moveWeekBeginning: function (noDays) {
            globalData.weekBeginning = moveDays(globalData.weekBeginning, noDays);
            return globalData.weekBeginning;
        },

        clear: function() {
            globalData.sessionId = null;
            globalData.displayName = null;
            globalData.accountTypeCode = null;
            globalData.date = null;
            globalData.weekBeginning = null;
        }
    };
});