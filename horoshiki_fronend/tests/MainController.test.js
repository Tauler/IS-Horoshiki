/**
 * Created by onyushkindv on 23.08.2016.
 */

describe('main fd Controllers', function() {
    beforeEach(module('mainControllers'));
    var $controller;

    beforeEach(inject(function(_$controller_){
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));

    describe('test 1', function() {
        it('test 1', function() {
            var $scope = {};
            var controller = $controller('MainViewController', { $scope: $scope });
            expect($scope.setting.active).toEqual(true);
        });
    });


});