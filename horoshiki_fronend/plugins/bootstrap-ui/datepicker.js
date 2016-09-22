/**
 * Created by OnyushkinDV on 10.03.2015.
 */
var datepickerDirectives = angular.module('datepickerDirectives', []);

datepickerDirectives.directive('datepicker', function () {

  return {
    restrict: 'E',
    scope: {
      ngModel: '=',
      ngChange: '&'
    },
    templateUrl: '/angular-html/directives/datepicker-single.html',

    link: function(scope, element){
      scope.$watch('ngModel', function(){
        if(scope.ngModel != undefined){
          var data = scope.ngModel.minMax;
          if(data != undefined && data.length == 2){
            element.find(".date-picker").datepicker({
              dateFormat: 'dd.mm.yy',
              minDate: data[0],
              maxDate: data[1],
              onClose: function(date){
                scope.$apply(function () {
                  if(date==undefined || date == ''){
                    scope.ngModel.select = '';
                  }else {
                    var d = date.split(".");
                    scope.ngModel.select = new Date(d[2], d[1] - 1, d[0]);
                    element.find(".date-picker").val(date);
                  }
                });
                scope.$apply(function () {
                  scope.ngChange();
                });
              }
            });

            if(scope.ngModel.select == undefined) {
              // var date = new Date();
              // element.find(".datepicker").val(dateFormatter(date));
              // scope.ngModel.select = date;
            }else{
              if(scope.ngModel.select==undefined || scope.ngModel.select == ''){
                element.find(".date-picker").val('');
              }else{
                var date = new Date(scope.ngModel.select);
                element.find(".date-picker").val(dateFormatter(date));
              }
              scope.ngModel.select = date;
            }

          }
        }
      }, true);
    }
  };

});


datepickerDirectives.directive('datepickerrange', function(){

  return {
    restrict: 'E',
    templateUrl: '/angular-html/directives/datepickerrange.html',
    scope: {
      ngModel: '='
    },

    link: function(scope, element){
      scope.$watch('ngModel', function(){
        if(scope.ngModel != undefined){
          var data = scope.ngModel.minMax;

          if(data != undefined && data.length == 2){
            element.find("#from").datepicker({
              dateFormat: 'dd.mm.yy',
              minDate: data[0],
              maxDate: data[1],
              onSelect: function(date){
                scope.ngModel.start = date;
                element.blur();
                element.find("#from").val(date);
              }
            });

            if(scope.ngModel.start != undefined){
              element.find("#from").val(scope.ngModel.start);
            }

            element.find("#to").datepicker({
              dateFormat: 'dd.mm.yy',
              minDate: data[0],
              maxDate: data[1],
              onSelect: function(date){
                scope.ngModel.end = date;
                element.blur();
                element.find("#to").val(date);
              }
            });

            if(scope.ngModel.end != undefined){
              element.find("#to").val(scope.ngModel.end);
            }
          }
        }
      }, true);
    }
  };

});