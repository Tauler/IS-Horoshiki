/**
 * Created by onyushkindv on 10.10.2016.
 */


var zonesControllers = angular.module('zonesControllers', []);

zonesControllers.controller('ZonesViewController', ['$scope', '$location', 'BackendService', 'SubdivisionService', 'PlatformsService',
    function ($scope, $location, BackendService, SubdivisionService, PlatformsService) {

        var obj_index = 0;

        $scope.model = {};
        $scope.model.objects = [];
        $scope.model.zoneForm = {};
        $scope.model.zoneForm.active = false;

        $scope.model.def = {};
        $scope.model.def.options = {};

        $scope.map = {};

        $scope.initMap = function (target) {
            $scope.map = target;

            var center = JSON.parse($scope.model.platform).YandexMap;
            $scope.setCenter(center);
        }

        $scope.setCenter = function (center) {
            if(center!=undefined && center!="")
                $scope.map.setCenter(JSON.parse(center));
        }

        $scope.addedPolygon = function (terget) {
            // console.log(terget.properties.get('index'));

            for ($index in $scope.model.objects) {
                if ($scope.model.objects[$index].index == terget.properties.get('index')) {
                    $scope.changeActiveZone($scope.model.objects[$index].index);
                }
            }

            $scope.map.geoObjects.each(function (geoObject) {
                if(geoObject.properties.get('index') == terget.properties.get('index') && geoObject.properties.get('isNew')==true) {
                    geoObject.editor.startDrawing();
                }
            });
        }

        $scope.addObject = function () {
            var zone = {
                index: obj_index,
                name: 'Зона ' + obj_index,
                options: {
                    editorDrawingCursor: 'crosshair',
                    editorMaxPoints: 200,
                    fillColor: '#444444',
                    strokeColor: '#444444',
                    fillOpacity: '0.1',
                    strokeWidth: 1
                },
                polygon: {
                    geometry: {
                        type: 'Polygon',
                        coordinates: []
                    },
                    properties: {index: obj_index, isNew: true}
                }
            }

            $scope.model.objects.push(zone);
            obj_index++;
        }

        $scope.deleteObject = function () {
            if ($scope.model.zoneForm.active && $scope.model.zoneForm.index != undefined && $scope.model.zoneForm != '') {

                $scope.map.geoObjects.each(function (geoObject) {
                    if (geoObject.properties.get('index') == $scope.model.zoneForm.index) {
                        $scope.map.geoObjects.remove(geoObject);
                    }
                });

                for ($index in $scope.model.objects) {
                    if ($scope.model.objects[$index].index == $scope.model.zoneForm.index) {
                        $scope.model.objects = $scope.model.objects.filter(function (item) {
                            return item !== $scope.model.objects[$index];
                        });
                        break;
                    }
                }

                $scope.model.zoneForm.active = false;
            }
        }

        $scope.changeActiveZoneWithMap = function (event) {
            $scope.changeActiveZone(event.get('target').properties.get('index'));
        }

        $scope.changeActiveZone = function (index) {
            for ($index in $scope.model.objects) {
                if ($scope.model.objects[$index].index == index) {
                    $scope.model.zoneForm.name = $scope.model.objects[$index].name;
                    $scope.model.zoneForm.index = $scope.model.objects[$index].index;
                    $scope.model.zoneForm.active = true;
                }
            }

            $scope.map.geoObjects.each(function (geoObject) {
                geoObject.options.set({fillOpacity: '0.1'});
                geoObject.editor.stopEditing();
                if (geoObject.properties.get('index') == index) {
                    geoObject.options.set({fillOpacity: '0.3'});
                    geoObject.editor.startEditing();
                }
                // console.log(JSON.stringify(geoObject.geometry.getCoordinates()));
            });

        }

        $scope.changeValueActiveZone = function () {
            for ($index in $scope.model.objects) {
                if ($scope.model.objects[$index].index == $scope.model.zoneForm.index) {
                    $scope.model.objects[$index].name = $scope.model.zoneForm.name;
                    $scope.model.objects[$index].index = $scope.model.zoneForm.index;
                }
            }
        }

        $scope.saveCenterPlatform = function () {
            var platform = JSON.parse($scope.model.platform);
            platform.YandexMap = JSON.stringify($scope.map.getCenter());


            // PlatformsService.edit(platform).success(function (result) {
            //
            //     if (result.Success == 1) {
            //
            //     } else {
            //         displayErrorMessage(result.ReasonMessage);
            //     }
            // }).error(function (result, status) {
            //     httpErrors($location.url(), status);
            // });

            $scope.model.platform = JSON.stringify(platform);
            console.log($scope.model.platform);
        }

        $scope.notActiveZone = function (event) {
            $scope.model.zoneForm.active = false;
            $scope.map.geoObjects.each(function (geoObject) {
                geoObject.options.set({fillOpacity: '0.1'});
                geoObject.editor.stopEditing();
            });
        }

        $scope.changeSubdivision = function () {
            $scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
            $scope.updateMapCoordinates($scope.model.platforms);
        }

        $scope.changePlatform = function () {
            if ($scope.model.platform != undefined && $scope.model.platform != '') {
            }


        }


        $scope.updateMapCoordinates = function (platforms) {

            if($scope.map.geoObjects!=undefined)
                $scope.map.geoObjects.removeAll();
            $scope.model.objects = [];

            if (platforms.length == undefined || platforms.length == 0)
                return;

            for (var $indexP in $scope.model.platforms) {
                var platform = $scope.model.platforms[$indexP];

                if (platform == undefined || platform.DeliveryZones == undefined || platform.DeliveryZones.length == 0)
                    return;

                for ($indexZ in platform.DeliveryZones) {
                    var deliveryZone =  platform.DeliveryZones[$indexZ];

                    var zone = {
                        index: obj_index,
                        name: deliveryZone.Name,
                        options: {
                            editorDrawingCursor: 'crosshair',
                            editorMaxPoints: 200,
                            fillColor: deliveryZone.DeliveryZoneType.Background,
                            strokeColor: deliveryZone.DeliveryZoneType.BorderColor,
                            fillOpacity: '0.1',
                            strokeWidth: 1
                        },
                        polygon: {
                            geometry: {
                                type: 'Polygon',
                                coordinates: JSON.parse(deliveryZone.Сoordinates)
                            },
                            properties: {index: obj_index}
                        }
                    }

                    $scope.model.objects.push(zone);
                    obj_index++;
                }
            }


        }

        $scope.getAllSubdivisions = function () {
            SubdivisionService.getSubdivisionsWithoutPaginate('Id', true).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.subdivisions = result.Data.Data;
                    if ($scope.model.subdivisions.length != 0) {
                        $scope.model.subdivision = JSON.stringify($scope.model.subdivisions[0]);
                        $scope.getAllPlatformBySubdivision(JSON.parse($scope.model.subdivision).Id);
                    }
                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }

        $scope.getAllPlatformBySubdivision = function (id) {
            PlatformsService.getAllBySubdivision(id).success(function (result) {
                if (result.Success == 1) {
                    $scope.model.platforms = result.Data;
                    if ($scope.model.platforms.length != 0) {
                        $scope.model.platform = JSON.stringify($scope.model.platforms[0]);

                    }
                    $scope.updateMapCoordinates($scope.model.platforms);

                } else {
                    displayErrorMessage(result.ReasonMessage);
                }
            }).error(function (result, status) {
                httpErrors($location.url(), status);
            });
        }


        $scope.getAllSubdivisions();
    }
]);
