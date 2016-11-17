/**
 * Created by doninvs on 16.11.2016.
 */

var targetControllers = angular.module('targetControllers', []);

targetControllers.controller('TargetMonthController', ['$scope', '$location', '$rootScope', 'TargetService', 'SubdivisionService', 'PlatformsService',
    function ($scope, $location, $rootScope, TargetService, SubdivisionService, PlatformsService) {
		
		$scope.model = {};
		
		$scope.model.targetMonth = {};
		
		$scope.model.years = enumYears;
        $scope.model.month = enumMonth;
		
		$scope.model.period = {};

		//текущий год
        $scope.model.period.year = angular.toJson(enumYears[0]);
        for (var $index in enumYears) {
            if (enumYears[$index] == (new Date()).getFullYear()) {
                $scope.model.period.year = angular.toJson(enumYears[$index]);
            }
        }
		
		//текущий месяц
        $scope.model.period.month = angular.toJson(enumMonth[0]);
        for (var $index in enumMonth) {
            if (enumMonth[$index].id == (new Date()).getMonth()) {
                $scope.model.period.month = angular.toJson(enumMonth[$index]);
            }
        }
		
		$scope.model.subdivisionIsDisabled = true;
        $scope.model.platformIsDisabled = true;
		
		// вытаскиваем подразделения и площадки после загрузки пользователя
		$rootScope.$watch('currentUserLoaded', function(){
            if($rootScope.currentUserLoaded == true){
                $scope.getAllSubdivisions();
            }
        });
		
		// выборка подразделений
		$scope.getAllSubdivisions = function(){
            SubdivisionService.getSubdivisionsWithoutPaginate('Id', true).success(function(result){
                if(result.Success == 1){
                    $scope.model.subdivisions = result.Data.Data;

                    if($scope.model.subdivisions.length != 0){
						if($rootScope.isChief()){
                            $scope.model.subdivision = JSON.stringify($scope.model.subdivisions[0]);
                            $scope.subdivisionIsDisabled = false;
                        }
                        if($rootScope.isManager()){
                            for($index in $scope.model.subdivisions){
                               if($scope.model.subdivisions[$index].Id == $rootScope.currentUser.Platform.SubDivision.Id){
                                   $scope.model.subdivision = JSON.stringify($scope.model.subdivisions[$index]);
                                   $scope.subdivisionIsDisabled = true;
                               }
                            }
                        }
                        if($scope.model.subdivision!=null){
                            $scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
                        }
                    }
                }else{
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        };
		
		// выборка площадок этих подразделений
		$scope.getAllPlatformBySubdivision = function(id){
            PlatformsService.getAllBySubdivision(id).success(function(result){
                if(result.Success == 1){
                    $scope.model.platforms = result.Data;
					
                    if($scope.model.platforms.length != 0){
                        if($rootScope.isChief()){
                            $scope.model.platform = JSON.stringify($scope.model.platforms[0]);
                            $scope.platformIsDisabled = false;
                        }
                        if($rootScope.isManager()){
                            for($index in $scope.model.platforms){
                                if($scope.model.platforms[$index].Id == $rootScope.currentUser.Platform.Id){
                                    $scope.model.platform = angular.toJson($scope.model.platforms[$index]);
                                    $scope.platformIsDisabled = true;
                                }
                            }
                        }
						if($scope.model.platform!=null){
							// создание и запрос модели плана после подгрузки подразделения и его площадок
                            $scope.model.targetMonth = $scope.createTargetModel();
							$scope.createTarget();
                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        };

		// пустая модель плана
		$scope.createTargetModel = function(){
			return {
				"Platform": {"Id": JSON.parse($scope.model.platform).Id},
				"Year": $scope.model.period.year,
				"Month": JSON.parse($scope.model.period.month).id + 1,
				"ChecksPerHourForPositionSushiChef": 0,
				"ChecksPerHourForPositionCourier": 0,
				"ChecksPerHourForPositionPizzaChef": 0,
				"Id": 0
			};
		}
		
		// запрос или создание модели плана
		$scope.createTarget = function(){
            TargetService.add($scope.model.targetMonth).success(function(result){
                if(result.Success == 1){
					$scope.model.targetMonth = result.Data;

					$scope.model.targetMonth.ChecksPerHourForPositionSushiChef = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionSushiChef);
					$scope.model.targetMonth.ChecksPerHourForPositionPizzaChef = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionPizzaChef);
					$scope.model.targetMonth.ChecksPerHourForPositionCourier = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionCourier);
                }else{
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function(result, status){
                httpErrors($location.url(), status);
            });
        }
		
		// сохранение или обновление модели плана
		$scope.updateTarget = function(){
            TargetService.update($scope.model.targetMonth).success(function(result){
                if(result.Success == 1){
					// ну типо получилось
                }else{
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function(result, status){
                httpErrors($location.url(), status);
            });
        }
		
		// форматирование ячейки чеков
		$scope.formatCheckValue = function(value){
			value = value.toString().replace(",", ".");
			if(!numberWithDotRegexp.test(value)){
				value = 0;
			}
			return parseFloat(value).toFixed(2);
		}
		
		// обновляем значения чеков
		$scope.changeChecksSushiChef = function(){
			$scope.model.targetMonth.ChecksPerHourForPositionSushiChef = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionSushiChef);
			$scope.updateTarget();
		}
		
		$scope.changeChecksPizzaChef = function(){
			$scope.model.targetMonth.ChecksPerHourForPositionPizzaChef = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionPizzaChef);
			$scope.updateTarget();
		}
		
		$scope.changeChecksCourier = function(){
			$scope.model.targetMonth.ChecksPerHourForPositionCourier = $scope.formatCheckValue($scope.model.targetMonth.ChecksPerHourForPositionCourier);
			$scope.updateTarget();
		}
		
		// повторяем запрос площадок при изменении подразделения
		$scope.reloadAllPlatformBySubdivision = function(){
			if($scope.model.subdivision!=null){
				$scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
			}
		}
		
		// повторяем запрос планов при изменении площадки, года, месяца
		$scope.reloadTarget = function(){
			$scope.model.targetMonth = $scope.createTargetModel();
			$scope.createTarget();
		}
    }
]);
