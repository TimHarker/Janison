'use strict';

angular.module('app.filters', [
    'readable.date'
]);

angular.module('app.directives', [
    'ui.sref.active.if'
]);

angular.module('app.controllers', [
    'header',
    'layout',
    'footer',
    'course',
    'courses',
    'module',
    'modules'
]);

angular.module('app.services', [
    'layout.service',
    'course.service',
    'module.service'
]);

angular.module('app', [
    'ui.router',
    'ui.router.title',
    'ngSanitize',
    'ngRoute',
    'ngAnimate',
    'ngResource',
    'ngMessages',
    'ui.bootstrap',
    'app.filters',
    'app.services',
    'app.directives',
    'app.controllers',
    'chieffancypants.loadingBar'
])

    .config([
        '$locationProvider', '$stateProvider', '$urlRouterProvider', 'cfpLoadingBarProvider',
        function ($locationProvider, $stateProvider, $urlRouterProvider, cfpLoadingBarProvider) {

            cfpLoadingBarProvider.includeSpinner = false;

            $urlRouterProvider.otherwise(function ($injector, $location) {
                var path = $location.path();
                if (path == null || path == '/')
                    return '/courses';
            });

            $locationProvider.html5Mode(true);
        }
    ])

    .run(['$rootScope', '$window', function ($rootScope, $window) {

    }]);
