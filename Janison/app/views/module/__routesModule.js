'use strict';
angular.module('app')
    .config([
        '$stateProvider', 'SITE_URL',
        function ($stateProvider, SITE_URL) {
            $stateProvider
                .state('module', {
                    url: '/module/:courseId',
                    templateUrl: SITE_URL + 'app/views/module/module.cshtml',
                    resolve: {
                        $title: function () { return 'Module'; }
                    }
                })
                .state('modules', {
                    url: '/modules/:courseId',
                    templateUrl: SITE_URL + 'app/views/module/modules.cshtml',
                    resolve: {
                        $title: function () { return 'Modules'; }
                    }
                })
        }]);