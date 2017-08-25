'use strict';
angular.module('footer', ['app.controllers'])
    .controller('FooterCtrl', [
        '$scope', '$window', '$q', '$rootScope',
        function ($scope, $window, $q, $rootScope) {
            var vm = this;
            
            vm.currentYear = (new Date()).getFullYear();

            vm.init = function () {
                //vm.refresh();
            };

            vm.refresh = function () {
                vm.working =
                    $q.all([
                        //service.getData(vm.id)
                    ])
                        .then(function (allResponse) {
                            //vm.data = allResponse[0].data;
                            return allResponse;
                        });
                return vm.working;
            };

            vm.init();

            return vm;
        }]);