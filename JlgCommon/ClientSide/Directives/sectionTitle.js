﻿var jlgCommonModule = angular.module("jlg.common");
jlgCommonModule.directive("sectionTitle", function () {
    return {
        restrict: "E",
        templateUrl: window.urlGetter("ClientSide/directives/sectionTitle.html"),
        scope: {
            title: "=",
            goBack: "="
        },
        controller: ["$scope", "sharedDataAndPopupSrv",
            function ($scope, sharedDataAndPopupSrv) {

                $scope.apfSharedData = sharedDataAndPopupSrv.sharedData;
                $scope.$watch("apfSharedData.loggedInContext", function (newValue) {
                    if (newValue) {
                        $scope.translatedText = newValue.translatedText;
                    }
                });
            }]
    };
});

