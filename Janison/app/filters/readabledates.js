'use strict';
angular.module('readable.date', ['app.filters'])
    .filter('readableDate', [ '$filter',
        function ($filter) {
            return function (value) {
                if (value) {
                    var moment = new Date();
                    var now = new Date(value).setHours(0, 0, 0, 0);
                    var daysAgo = new Date((moment.setHours(0, 0, 0, 0))).setDate(new Date((moment.setHours(0, 0, 0, 0))).getDate() - 7);
                    if (now > daysAgo) {
                        var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
                        var today = new Date((moment.setHours(0, 0, 0, 0))).getDay();
                        var day = new Date(new Date(value).setHours(0, 0, 0, 0)).getDay();
                        if (today == day) return 'Today';
                        if (day == 6 && today == 0 ||
                            day == today - 1) return 'Yesterday';
                        return days[day];
                    }
                }
                return $filter('date')(value, 'd/M/yyyy');
            };
        }]);