'use strict';
angular.module('modules', ['app.controllers'])
    .controller('ModulesCtrl', [
        '$scope', '$window', '$q', '$rootScope', '$stateParams', 'moduleService',
        function ($scope, $window, $q, $rootScope, $stateParams, moduleService) {
            var vm = this;

            vm.course = {};
            vm.itemFirst = 0;
            vm.itemCount = 3;

            vm.init = function () {
                vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        moduleService.getModules($stateParams.courseId)
                    ])
                        .then(function (allResponse) {
                            vm.course = allResponse[0].data;
                            return allResponse;
                        });
                return vm.working;
            };

            vm.page = function () {
                if (!vm.course.Modules) {
                    return 0;
                }
                return Math.ceil(vm.course.Modules.length / vm.itemCount);
            }

            vm.init();

            return vm;
        }]);