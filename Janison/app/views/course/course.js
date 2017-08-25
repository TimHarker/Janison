'use strict';
angular.module('course', ['app.controllers'])
    .controller('CourseCtrl', [
        '$scope', '$window', '$q', '$rootScope', 'courseService', '$state', '$stateParams',
        function ($scope, $window, $q, $rootScope, courseService, $state, $stateParams) {
            var vm = this;

            vm.course = {
                Duration: null,
                Enabled: true
            };
            vm.pristineCourse = null;
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
                vm.pristineCourse = angular.copy(vm.course);
                if ($stateParams.courseId) vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        courseService.getCourse($stateParams.courseId)
                    ])
                        .then(function (allResponse) {
                            vm.course = allResponse[0].data;
                            vm.pristineCourse = angular.copy(vm.course);
                            return allResponse;
                        });
                return vm.working;
            };

            vm.validate = function () {
                var any = false;
                if ($scope.course.$invalid || ($scope.course.$invalid == null)) {
                    angular.forEach($scope.course.$error, function (field) {
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
                    vm.working = courseService.saveCourse(vm.course).then(function (response) {
                        $state.go('courses');
                        $rootScope.$broadcast('refreshHeader');
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
                var clean = angular.copy(vm.course);
                return JSON.stringify(clean) != JSON.stringify(vm.pristineCourse);
            }

            vm.init();

            return vm;
        }]);