'use strict';
angular.module('courses', ['app.controllers'])
    .controller('CoursesCtrl', [
        '$scope', '$window', '$q', '$rootScope', 'courseService', '$uibModal', '$state',
        function ($scope, $window, $q, $rootScope, courseService, $uibModal, $state) {
            var vm = this;

            vm.courses = [];
            vm.itemFirst = 0;
            vm.itemCount = 3;

            vm.init = function () {
                vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        courseService.getCourses()
                    ])
                        .then(function (allResponse) {
                            vm.courses = allResponse[0].data;
                            return allResponse;
                        });
                return vm.working;
            };

            vm.edit = function (courseId, event) {
                $state.go('course', { courseId: courseId });
                event.stopPropagation(); // stops navigating to Module through row click
            };

            // this Modal Dialog controller would normally be split into a seperate file
            vm.deletePrompt = function (courseId, event) {
                event.stopPropagation();
                $uibModal.open({
                    animation: false,
                    ariaLabelledBy: 'modal-title',
                    ariaDescribedBy: 'modal-body',
                    templateUrl: 'deleteModalContent.html',
                    controller: [
                        '$scope', '$uibModalInstance', '$q', 'courseService', '$rootScope',
                        function ($scope, $uibModalInstance, $q, courseService, $rootScope) {
                            $scope.ok = function () {
                                vm.working = courseService.deleteCourse($scope.$resolve.courseId).then(function (response) {
                                    $uibModalInstance.close();
                                    vm.refresh();
                                    $rootScope.$broadcast('refreshHeader');
                                    return response;
                                }, function (response) {
                                    $scope.error = response.data.Message;
                                    return $q.reject(response);
                                });
                            };
                            $scope.cancel = function () {
                                $uibModalInstance.dismiss();
                            };
                        }
                    ],
                    resolve: {
                        courseId: function () {
                            return courseId;
                        }
                    }
                });
            };

            vm.page = function () {
                if (!vm.courses) {
                    return 0;
                }
                return Math.ceil(vm.courses.length / vm.itemCount);
            }

            vm.init();

            return vm;
        }]);