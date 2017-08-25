'use strict';
angular.module('module', ['app.controllers'])
    .controller('ModuleCtrl', [
        '$scope', '$window', '$q', '$rootScope', 'moduleService', '$stateParams', '$state', '$filter',
        function ($scope, $window, $q, $rootScope, moduleService, $stateParams, $state, $filter) {
            var vm = this;

            vm.module = {
                CourseID: $stateParams.courseId,
                Duration: null,
                DateCreated: $filter('date')(new Date(), 'dd/MM/yyyy')
            };
            vm.pristineModule = null;
            vm.ErrorMessage = '';
            vm.durations = [
                { Name: 'Select a Duration', Value: null },
                { Name: '30 mins', Value: 30 },
                { Name: '45 mins', Value: 45 },
                { Name: '60 mins', Value: 60 },
                { Name: '75 mins', Value: 75 },
                { Name: '90 mins', Value: 90 },
                { Name: '120 mins', Value: 120 },
                { Name: '180 mins', Value: 180 }
            ];

            vm.init = function () {
                vm.pristineModule = angular.copy(vm.module);
                //vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        //moduleService.getModule($statParams.moduleId)
                    ])
                        .then(function (allResponse) {
                            //vm.module = allResponse[0].data;
                            //vm.pristineModule = angular.copy(vm.module);
                            return allResponse;
                        });
                return vm.working;
            };

            vm.validate = function () {
                var any = false;
                if ($scope.module.$invalid || ($scope.module.$invalid == null)) {
                    angular.forEach($scope.module.$error, function (field) {
                        angular.forEach(field, function (errorField) {
                            errorField.$setTouched();
                            any = true;
                        });
                    });
                    return !any;
                }
                return true;
            };

            vm.save = function () {
                if (vm.validate()) {
                    vm.ErrorMessage = '';
                    vm.working = moduleService.saveModule(vm.module).then(function (response) {
                        $state.go('modules', { courseId: $stateParams.courseId });
                        return response;
                    }, function (response) {
                        if (response.errors.type == "ModelState" || response.errors.type == "SimpleError") {
                            response.errors.handled = true;
                            vm.ErrorMessage = response.errors.message;
                        }
                        return $q.reject(response);
                    });
                    return null;
                }
            }

            vm.isDirty = function () {
                var clean = angular.copy(vm.module);
                return JSON.stringify(clean) != JSON.stringify(vm.pristineModule);
            }

            vm.init();

            return vm;
        }]);