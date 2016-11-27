/**
 * Created by onyushkindv on 15.09.2016.
 */
var timepickerDirectives = angular.module('timepickerDirectives', []);

datepickerDirectives.directive('timepicker', function () {

    return {
        restrict: 'E',
        scope: {
            ngModel: '=',
            ngDisabled: '=',
            ngChange: '&'
        },
        template: "<input class='form-control time-picker' maxlength='5' type='text'>",

        link: function (scope, element) {
            element.find(".time-picker").on("changeValue.timepicker", function (e) {
                console.log("123");
                scope.$apply(function () {
                    scope.ngModel = element.find(".time-picker").val();
                });
                scope.$apply(function () {
                    scope.ngChange();
                });

            });

            scope.$watch('ngModel', function () {
                if (scope.ngModel != undefined) {
                    var data = scope.ngModel;
                    
                    element.find(".time-picker").timepicker({
                        showMeridian: false,
                        minuteStep: 5,
                        isOpen: true,
                    });
                    element.find(".time-picker").timepicker('setTime', data);
                    element.find(".time-picker").attr("disabled", scope.ngDisabled);
                }
            }, true);
        }
    };

});
