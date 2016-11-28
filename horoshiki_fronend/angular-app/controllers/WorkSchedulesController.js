/**
 * Created by doninvs on 21.11.2016.
 */
 
var workSchedulesControllers = angular.module('workSchedulesControllers', []);

workSchedulesControllers.controller('WorkSchedulesListController', ['$scope', '$location', '$rootScope', '$compile', 'SubdivisionService', 'PlatformsService', 'DictionaryService', 'ShiftPersonalScheduleService', '$window',
    function ($scope, $location, $rootScope, $compile, SubdivisionService, PlatformsService, DictionaryService, ShiftPersonalScheduleService, $window) {

        $scope.model = {};
		
		$scope.model.targetModel = {};
		
		$scope.model.years = enumYears;
        $scope.model.month = enumMonth;
		
		$scope.model.period = {};

		$scope.model.period.yearSelected = null;
		$scope.model.period.monthSelected = null;
		$scope.model.period.daySelected = null;
		
		$scope.model.period.dayNoNeeded = '--';
		
		$scope.model.selectedDepartment = {};
		$scope.model.selectedSubDepartment = null;
		
		$scope.model.table = {};
		
		$scope.model.sunday = {};
		$scope.model.sunday.name = 'вс';
		
		$scope.model.pageStatus = {};
		$scope.model.pageStatus.saving = false;
		$scope.model.pageStatus.loading = false;
		
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
		
		// дни в месяце
		$scope.getDays = function(){
			$scope.model.days = [];
			$scope.model.days.push($scope.model.period.dayNoNeeded);
			
			var d = new Date($scope.model.period.year.toString(), (JSON.parse($scope.model.period.month).id + 1).toString(), 0).getDate();

			for (var i = 0; i < d; i++) {
				$scope.model.days.push(i+1);
			}
			
			$scope.model.period.day = $scope.model.days[0];
		}
		$scope.getDays();
		
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
							$scope.reloadTableModel();
                        }
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        };
		
		// повторяем запрос площадок при изменении подразделения
		$scope.reloadAllPlatformBySubdivision = function(){
			if($scope.model.subdivision!=null){
				$scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
			}
		}
		
		// получаем департаменты
		$scope.getAllDepartments = function(){
			DictionaryService.getDepartments().success(function(result){
                if(result.Success == 1){
					$scope.model.departments = result.Data;
					
					if($scope.model.departments.length != 0){
						// устанавливаем дефолтный департамент
						$scope.model.selectedDepartment = $scope.model.departments[0];
					
						$scope.getAllSubDepartments();
					}
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
		}
		
		// получаем поддепартаменты
		$scope.getAllSubDepartments = function(){
			DictionaryService.getSubDepartments().success(function(result){
                if(result.Success == 1){
					$scope.model.subDepartments = result.Data;
				
					// добавляем поддепартаменты в департаменты
					for($di in $scope.model.departments){
						$scope.model.departments[$di].subDepartments = [];
						
						for($sdi in $scope.model.subDepartments){
							if($scope.model.departments[$di].Id == $scope.model.subDepartments[$sdi].DepartmentId){
								$scope.model.departments[$di].subDepartments.push($scope.model.subDepartments[$sdi]);
							}
						}
					}
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
		}
		
		$scope.getAllDepartments();
		
		// получаем типы смен
		$scope.getAllShiftTypes = function(){
			DictionaryService.getShiftTypes().success(function(result){
                if(result.Success == 1){
					$scope.model.shiftTypes = result.Data;
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
		}
		
		$scope.getAllShiftTypes();
		
		// запрос таблицы
		$scope.reloadTableModel = function(){
			if($scope.model.period.yearSelected!=null && $scope.model.period.monthSelected !=null)
			{
				if($scope.model.period.daySelected != $scope.model.period.dayNoNeeded){
					var isOnDay = true;
					var date = dateFormatterBackend(new Date((JSON.parse($scope.model.period.monthSelected).id + 1).toString()+'/'+numb2($scope.model.period.daySelected)+'/'+$scope.model.period.yearSelected.toString()));
				}else{
					var isOnDay = false;
					var date = dateFormatterBackend(new Date((JSON.parse($scope.model.period.monthSelected).id + 1).toString()+'/01/'+$scope.model.period.yearSelected.toString()));
				}
				
				if($scope.model.selectedSubDepartment != null){
					var subDepId = $scope.model.selectedSubDepartment.Id;
				}else{
					var subDepId = 0;
				}
				
				var model = {
					"Platform": {
						"Id": JSON.parse($scope.model.platform).Id
					},
					"Departament": {
						"Id": $scope.model.selectedDepartment.Id,
					},
					"SubDepartaments": [{
						"Id": subDepId
					}],
					"Date": date,
					"IsOnDay": isOnDay
				};
				
				$scope.model.pageStatus.loading = true;
				ShiftPersonalScheduleService.table(model).success(function(result){
					if(result.Success == 1){
						$scope.model.table = result.Data;
						
						// заполняем массив индексов воскресных дней (для подсветки)
						if($scope.model.table.HeaderScheduleColumns.length > 0){
							$scope.model.sunday.indexes = [];
							
							for($i in $scope.model.table.HeaderScheduleColumns){
								if($scope.model.table.HeaderScheduleColumns[$i].DayOfWeekDescr == $scope.model.sunday.name){
									$scope.model.sunday.indexes.push($i);
								}
							}
						}
					} else {
						displayErrorMessage(result.ReasonMessage);
					}
					$scope.model.pageStatus.loading = false;
				}).error(function (result, status) {
					$scope.model.pageStatus.loading = false;
					httpErrors($location.url(), status);
				});
			}
		}

		// всплывающий блок с выбором даты
		$scope.dynamicPopover = {
			templateUrl: '/angular-html/partial/popover.work.scheduler.html',
			isOpen: false
		};
		
		$scope.parJson = function(json){
			return JSON.parse(json);
		}
		
		$scope.changeDatePopover = function(){
			$scope.dynamicPopover.isOpen = false;
			
			$scope.model.period.yearSelected = $scope.model.period.year;
			$scope.model.period.monthSelected = $scope.model.period.month;
			$scope.model.period.daySelected = $scope.model.period.day;
			
			$scope.reloadTableModel();
		}
		
		$scope.closeDatePopover = function(){
			$scope.dynamicPopover.isOpen = false;
		}
		
		// переключение департаментов
		$scope.selectDepartmentView = function(department, subDepartment){
			$scope.model.selectedDepartment = department;
			$scope.model.selectedSubDepartment = subDepartment;
			
			$scope.reloadTableModel();
		}
		
		// функции форматирования для таблицы
		$scope.formatHeaderDate = function(date){
			return new Date(dateFormatterBackendToSafari(date)).getDate();
		}
		
		$scope.showIfMoreZero = function(number){
			//return number > 0 ? number : '';
			return number; //debug
		}
		
		$scope.isRowTypeMorning = function(guid){
			return guid == enumShiftCountRowsType.morning;
		}
		
		$scope.isRowTypeEvening = function(guid){
			return guid == enumShiftCountRowsType.evening;
		}
		
		$scope.isRowTypeNight = function(guid){
			return guid == enumShiftCountRowsType.night;
		}
		
		$scope.isRowTypePowerup = function(guid){
			return guid == enumShiftCountRowsType.powerup;
		}
		
		$scope.showDepartmentName = function(){
			if($scope.model.selectedSubDepartment==null){
				return $scope.model.selectedDepartment.Value;
			}
			return $scope.model.selectedSubDepartment.Value;
		}
		
		$scope.todayIsSunday = function(index){
			if($scope.model.sunday.indexes.indexOf(index.toString()) > -1){
				return true;
			}
			return false;
		}
		
		$scope.getRandomId = function(){
			return Math.floor(Math.random()*10000);
		}
		
		$scope.showUserSchedules = function(schedules){
			var arr = [];
			if(schedules == null){
				return "";
			}
			for($i in schedules){
				arr.push(schedules[$i].ShiftType.Socr);
			}
			return arr.join('/');
		}
		
		$scope.selectedShiftTypesDefault = function(schedules){
			$scope.model.selectedShiftTypes = {};
			$scope.model.selectedShiftTypes.ids = {};
			
			for($i in enumShiftCountRowsType){
				$scope.model.selectedShiftTypes.ids[enumShiftCountRowsType[$i]] = false;
			}
		
			if(schedules != null){
				for($i in schedules){
					$scope.model.selectedShiftTypes.ids[schedules[$i].ShiftType.Guid] = true;
				}
			}
		}
		
		// обновление ячейки
		$scope.setUserShiftType = function(userId, date, shiftTypeGuid){
			var schedulesArray = [];
			
			//сброс всех при выборе смены Усиления
			if(shiftTypeGuid == enumShiftCountRowsType.powerup){
				for($i in enumShiftCountRowsType){
					if(enumShiftCountRowsType[$i] != enumShiftCountRowsType.powerup){
						$scope.model.selectedShiftTypes.ids[enumShiftCountRowsType[$i]] = false;
					}
				}
			}else{
				$scope.model.selectedShiftTypes.ids[enumShiftCountRowsType.powerup] = false;
			}

			for($i in $scope.model.shiftTypes){
				if($scope.model.selectedShiftTypes.ids[$scope.model.shiftTypes[$i].Guid]){
					var obj = {
						"ShiftType": {
							"Id": $scope.model.shiftTypes[$i].Id,
						},
						"User": {
							"Id": userId
						},
						"Date": dateFormatterBackend(new Date(dateFormatterBackendToSafari(date)))
					}

					schedulesArray.push(obj);
				}
			}

			var model = {
				"User": {
					"Id": userId
				},
				"ShiftPersonalSchedules": schedulesArray,
				"Date": dateFormatterBackend(new Date(dateFormatterBackendToSafari(date)))
			};

			$scope.model.pageStatus.saving = true;
			ShiftPersonalScheduleService.updateCell(model).success(function(result){
                if(result.Success == 1){
					
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
				$scope.model.pageStatus.saving = false;
            }).error(function (result, status) {
				$scope.model.pageStatus.saving = false;
                httpErrors($location.url(), status);
            });
		}
		
		// вызов перегрузки таблицы из jQuery
		$window.reloadTableModelWrapper = function(){
			$scope.reloadTableModel();
		}
    }
]);