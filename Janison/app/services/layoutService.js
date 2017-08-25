'use strict';
angular.module('layout.service', ['app.services'])
    .service('layoutService', [
        '$http', 'API_URL',
        function ($http, API_URL) {
            var service = {};

            service.getTotalCourseCount = function () {
                return $http.get(API_URL + 'api/Layout/getTotalCourseCount');
            };

            return service;
        }])