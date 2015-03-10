﻿var directivesModule = angular.module("directives");
directivesModule.directive("datePicker", function () {
    return {        
        restrict: "E",
        templateUrl: window.urlGetter("scripts/app/_directives/shared/datePicker.html"),
        scope: {
            name: "=",
            selected: "=",
            selectedYear: "=",
            selectedMonth: "=",
            min: "=",
            max: "=",
            disabled: "="
        },
        controller: ["$scope", "$timeout", "dateHelperSrv",
            function ($scope, $timeout, dateHelperSrv) {
                
            $scope.datePickerMode = "month";
            $scope.dateOptions = {
                minMode: "month",
                yearRange: 20,
                formatMonth: "MMM"
            };

            $scope.openCalendar = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            };

            $scope.$watch("selected", function (newValue, oldValue) {
                $scope.selectedLocal = newValue;
            });

            $scope.$watch("selectedLocal", function (newValue, oldValue) {
                if (newValue) {

                    if ($scope.min
                        && $scope.max) {

                        if (dateHelperSrv.compareMMMyyyyDates(newValue, $scope.min) == -1
                            || dateHelperSrv.compareMMMyyyyDates(newValue, $scope.max) == 1) {

                            $scope.selectedLocal = oldValue;
                            return;
                        }
                    }

                    var selectedDateString;
                    if (dateHelperSrv.isDateObject(newValue)) {
                        selectedDateString = dateHelperSrv.toMMMyyyyDateString(newValue);
                    } else {
                        selectedDateString = newValue;
                    }

                    var dateYearMonth = dateHelperSrv.getYearMonth(selectedDateString);

                    $scope.selectedMonth = dateYearMonth.month;
                    $scope.selectedYear = dateYearMonth.year;

                    if ($scope.selected != selectedDateString) {
                        $scope.selected = selectedDateString;
                    }
                }
            });
        }]
    };
});

