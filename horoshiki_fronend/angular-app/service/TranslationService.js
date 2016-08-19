/**
 * Created by onyushkindv on 19.08.2016.
 */

var translationServices = angular.module('translationServices', []);

translationServices.service('TranslationService', function($resource) {

        var selectedLanguage = defaultLang;

        this.setLanguage = function(lang){
            selectedLanguage = lang;
        }

        this.getTranslation = function($scope) {
            var languageFilePath = '/angular-app/lang/translation_' + selectedLanguage + '.json';

            $resource(languageFilePath).get(function (data) {
                $scope.translation = data;
            });
        };
    });