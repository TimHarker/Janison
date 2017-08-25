'use strict';
angular.module('layout', ['app.controllers'])
    .controller('LayoutCtrl', [
        '$scope', '$window', '$q', '$rootScope', 'layoutService',
        function ($scope, $window, $q, $rootScope, layoutService) {
            var layvm = this;

            layvm.init = function () {
                //layvm.refresh();
            };

            layvm.refresh = function () {
                layvm.working =
                    $q.all([
                        //layoutService.getSummaryByCompany(layvm.companyId)
                    ])
                        .then(function (allResponse) {
                            //layvm.companySummary = allResponse[0].data;
                            return allResponse;
                        });
                return layvm.working;
            };

            layvm.init();

            return layvm;
        }]);