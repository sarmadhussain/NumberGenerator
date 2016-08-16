var mainapp = angular.module("mainapp", []);
mainapp.controller('mainController', ['$scope', '$http', function ($scope, $http) {
    $scope.AllNumbers = "All nums";
    $scope.EvenNumbers = "even nums like 2,4,6";
    $scope.OddNumbers = "odd nums like 1,3,5,7";
    $scope.CEZNumbers = "cez series like 12c4e etc";
    $scope.FibonaciNumbers = "0112358,13";
    $scope.ajax_request = null;
    $scope.inputNumber = 0;

    $scope.GenerateSequences = function () {
        if ($scope.ajax_request && $scope.ajax_request.readyState != 4) {
            $scope.ajax_request.abort();
        }
                
        // send ajax
        $scope.ajax_request = $.ajax({
            url: urlNumberGenerator,
            type: 'POST',
            data: {
                number: $scope.inputNumber
            },
            dataType: 'json',
            success: function (result) {
                // on successful operation
                if (result.nvm && result.nvm != null) {
                    $scope.AllNumbers = result.nvm.allNumbers.toString();
                    $scope.EvenNumbers = result.nvm.evenNumbers.toString();
                    $scope.OddNumbers = result.nvm.oddNumbers.toString();
                    $scope.CEZNumbers = result.nvm.cezNumbers.toString();
                    $scope.FibonaciNumbers = result.nvm.fibNumbers.toString();
                    $scope.$apply();
                }
            },
            error: function () {
                // some internal error occurred
            },
            complete: function (xhr, status) {
                // do some universal operation here
            }
        });
    };
}]);