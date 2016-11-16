/**
 * Created by doninvs on 15.11.2016.
 */

var userLoadingDirectives = angular.module('userLoadingDirectives', []);

userLoadingDirectives.directive('userLoadingIndicator', ['$rootScope', '$http', function($rootScope, $http){

	return {
		restrict: 'E',
		template: '<div class="col-lg-12 loading-spinner"><h1>Загрузка... <i class="fa fa-cog fa-spin"></i></h1></div>',
		link:function(scope, element, attrs){
			$rootScope.$watch('currentUserLoaded', function(){
				if($rootScope.currentUserLoaded == true){
					element.addClass('ng-hide');
					$("#main-content-wrapper").removeClass('ng-hide');
					$("#left-sidebar").removeClass('ng-hide');
				}else{
					element.removeClass('ng-hide');
					$("#main-content-wrapper").addClass('ng-hide');
					$("#left-sidebar").addClass('ng-hide');
				}
			});
		}
	};
}]);
