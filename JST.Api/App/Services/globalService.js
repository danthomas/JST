app.factory('globalService', function (globalData, $location, $timeout) {

    function moveDays(date, days) {
        date = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        date = new Date(date.setTime(date.getTime() + days * 86400000));
        return date;
    }

    var timeout;

    return {

        landing: function () {
            
            if (globalData.roleCodes.indexOf('Competitor') >= 0) {
                $location.url('/competitorWorkoutDay');
            }
            else if (globalData.roleCodes.indexOf('Trainer') >= 0) {
                $location.url('/trainerSchedule');
            }
            else if (globalData.roleCodes.indexOf('Admin') >= 0) {
                $location.url('/adminHome');
            }
        },

        url: function (url, replace, setBackUrl) {
            if (setBackUrl) {
                globalData.backUrl = $location.$$path;
            }
            if (replace) {
                $location.url(url).replace();
            } else {
                $location.url(url);
            }
        },

        backUrl: function (otherwiseUrl) {
            if (globalData.backUrl) {
                $location.url(globalData.backUrl);
                globalData.backUrl = null;
            } else if (otherwiseUrl) {
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

        clear: function () {
            globalData.sessionId = null;
            globalData.displayName = null;
            globalData.accountTypeCode = null;
            globalData.date = null;
            globalData.weekBeginning = null;
            globalData.message = null;
        },

        setMessage: function (messages) {

            if (messages && messages.length == 1) {
                //clear existing message timeout
                if (timeout) {
                    $timeout.cancel(timeout);
                }

                //set message and timeout
                globalData.message = messages[0];

                timeout = $timeout(function() {
                    globalData.message = null;
                    timeout = null;
                }, 5000);
            } 
        }
    };
});