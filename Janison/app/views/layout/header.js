'use strict';
angular.module('header', ['app.controllers'])
    .controller('HeaderCtrl', [
        '$scope', '$window', '$q', '$rootScope', 'layoutService',
        function ($scope, $window, $q, $rootScope, layoutService) {
            var vm = this;

            vm.totalCourseCount = 0;

            vm.init = function () {
                // used to refresh header data when needed through rootScope broadcast
                $scope.$on("refreshHeader", function (event) {
                    vm.refresh();
                });
                vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        layoutService.getTotalCourseCount()
                    ])
                        .then(function (allResponse) {
                            vm.totalCourseCount = allResponse[0].data;
                            return allResponse;
                        });
                return vm.working;
            };

            vm.init();

            return vm;
        }]);