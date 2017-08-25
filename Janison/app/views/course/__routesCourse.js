'use strict';
angular.module('app')
    .config([
        '$stateProvider', 'SITE_URL',
        function ($stateProvider, SITE_URL) {
            $stateProvider
                .state('course', {
                    url: '/course/:courseId',
                    templateUrl: SITE_URL + 'app/views/course/course.cshtml',
                    resolve: {
                        $title: function () { return 'Course'; }
                    }
                })
                .state('courses', {
                    url: '/courses',
                    templateUrl: SITE_URL + 'app/views/course/courses.cshtml',
                    resolve: {
                        $title: function () { return 'Courses'; }
                    }
                })
        }]);