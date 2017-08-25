'use strict';
angular.module('ui.sref.active.if', ['app.directives'])
    .directive('uiSrefActiveIf', [
        '$state',
        function ($state) {
            return {
                restrict: "A",
                scope: {
                    uiSrefActiveIf: '@'
                },
                controller: [
                    '$scope', '$element', '$attrs',
                    function ($scope, $element, $attrs) {
                        var state = $scope.uiSrefActiveIf; // $attrs.uiSrefActiveIf;

                        function update() {
                            if ($state.includes(state) || $state.is(state)) {
                                $element.addClass("active");
                            } else {
                                $element.removeClass("active");
                            }
                        }

                        $scope.$on('$stateChangeSuccess', update);
                        update();
                    }
                ]
            };
        }]);