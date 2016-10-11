/**
 * Created by onyushkindv on 10.10.2016.
 */


var zonesControllers = angular.module('zonesControllers', []);

zonesControllers.controller('ZonesViewController', ['$scope', '$location', 'BackendService',
    function ($scope, $location, BackendService) {

        var obj_index = 0;

        $scope.model = {};
        $scope.model.objects = [];
        $scope.model.zoneForm = {};
        $scope.model.zoneForm.active = false;
        $scope.map = {};


        $scope.initMap = function (target) {
            $scope.map = target;
        }

        $scope.addedPolygon = function (terget) {
            console.log(terget.properties.get('index'));

            for ($index in $scope.model.objects) {
                if ($scope.model.objects[$index].index == terget.properties.get('index')) {
                    $scope.changeActiveZone($scope.model.objects[$index].index);
                }
            }

        }


        $scope.addObject = function () {

            var zone = {
                index: obj_index,
                name: 'Зона ' + obj_index,
                options: {
                    editorDrawingCursor: 'crosshair',
                    editorMaxPoints: 50,
                    fillColor: '#00cc00',
                    strokeColor: '#00034F',
                    fillOpacity: '0.3',
                    strokeWidth: 1
                },
                polygon: {
                    geometry: {
                        type: 'Polygon',
                        coordinates: []
                    },
                    properties: {index: obj_index}
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
                    console.log($index);
                    console.log($scope.model.objects[$index].index);
                    if ($scope.model.objects[$index].index == $scope.model.zoneForm.index) {
                        $scope.model.objects = $scope.model.objects.filter(function (item) {
                            return item!==$scope.model.objects[$index];
                        });
                        break;
                    }
                }

                $scope.model.zoneForm.active = false;
            }
        }

        // $scope.editZone = function (geoObject) {
        //
        //     // $scope.map.geoObjects.add(polygon);
        //
        //
        //     // $scope.map.geoObjects.each(function (geoObject) {
        //     //     if (geoObject.properties.get('id') == id) {
        //             geoObject.editor.stopEditing();
        //             console.log(geoObject.geometry.getCoordinates());
        //     //     }
        //     // });
        //
        //     // console.log(object.getCoordinates());
        //     // object.editor.stopEditing();
        // }

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
        }

        $scope.changeValueActiveZone = function () {
            for ($index in $scope.model.objects) {
                if ($scope.model.objects[$index].index == $scope.model.zoneForm.index) {
                    $scope.model.objects[$index].name = $scope.model.zoneForm.name;
                    $scope.model.objects[$index].index = $scope.model.zoneForm.index;
                }
            }
        }

        $scope.notActiveZone = function (event) {
            $scope.model.zoneForm.active = false;
        }


    }
]);
