'use strict';
angular.module('course.service', ['app.services'])
    .service('courseService', [
        '$http', 'API_URL',
        function ($http, API_URL) {
            var service = {};

            service.getCourse = function (courseId) {
                return $http.get(API_URL + 'api/Course/GetCourse/' + courseId);
            };

            service.getCourses = function () {
                return $http.get(API_URL + 'api/Course/GetCourses/');
            };

            service.deleteCourse = function (courseId) {
                return $http.get(API_URL + 'api/Course/DeleteCourse/' + courseId);
            };

            service.saveCourse = function (course) {
                return $http.post(API_URL + 'api/Course/SaveCourse', course);
            };


            return service;
        }])