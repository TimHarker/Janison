'use strict';
angular.module('module.service', ['app.services'])
    .service('moduleService', [
        '$http', 'API_URL',
        function ($http, API_URL) {
            var service = {};

            service.getModules = function (courseId) {
                return $http.get(API_URL + 'api/Module/GetModules/' + courseId);
            };

            service.saveModule = function (module) {
                return $http.post(API_URL + 'api/Module/SaveModule', module);
            };

            return service;
        }])