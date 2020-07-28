
var app = angular.module('MyApp', [])

app.controller('myCtrl', function ($scope, $http, $rootScope) {
    $scope.records = {};
    $scope.sciencerecords = {};
    $scope.englishrecords = {};
    $scope.hindirecords = {};
    $scope.Profiledetails = "";
    $scope.Name = "";
    $scope.Class = "";
   
    
  
    $scope.GetProfileDetails = function () {
        $http({
            method: "GET",
            url: '/Common/GetProfiledetails',
            params: { RegId: $scope.RegId }
        })
            .then(function mySuccess(response) {
            if (response.data.length > 0) {
                if (response.data[0].Role == 'Student' ) {
                    $scope.Name = response.data[0].Name;
                    $scope.Class = response.data[0].Class;
                    $scope.Address = response.data[0].Address;
                    $scope.Phone = response.data[0].Phone;
                    $scope.UID = response.data[0].RegId;
                    $scope.Getsubjectmathsvedio();
                    $scope.Getsubjecthindivedio();
                    $scope.Getsubjectsciencevedio();
                    $scope.Getsubjectenglishvedio();
                }
                else {
                    window.location.href = '/Login/Index';

                }
            }
            else
            {
                window.location.href = '/Login/Index';
            }
        }, function myError(response) {
                $scope.Profiledetails = response.statusText;
        });
    }

    $scope.Getsubjectmathsvedio = function () {
        $http({
            method: "GET",
            url: '/Common/Getsubjectmathsvedio',
            params: {cls: $scope.Class }
        }).then(function mySuccess(response) {
            $scope.records = response.data;

        }, function myError(response) {
            $scope.records = response.statusText;
        });
    }
    ///----------------------------------english-------------
    $scope.Getsubjectenglishvedio = function () {
        $http({
            method: "GET",
            url: '/Common/Getsubjectenglishvedio',
            params: { cls: $scope.Class }
        }).then(function mySuccess(response) {
            $scope.englishrecords = response.data;

        }, function myError(response) {
                $scope.englishrecords = response.statusText;
        });
    }
    /////////------------------------------science--------------
    $scope.Getsubjectsciencevedio = function () {
        $http({
            method: "GET",
            url: '/Common/Getsubjectsciencevedio',
            params: { cls: $scope.Class }
        }).then(function mySuccess(response) {
            $scope.sciencerecords = response.data;

        }, function myError(response) {
                $scope.sciencerecords = response.statusText;
        });
    }
    ////-------------------hindi-----------------
    $scope.Getsubjecthindivedio = function () {
        $http({
            method: "GET",
            url: '/Common/Getsubjecthindivedio',
            params: { cls: $scope.Class }
        }).then(function mySuccess(response) {
            $scope.hindirecords = response.data;

        }, function myError(response) {
                $scope.hindirecords = response.statusText;
        });
    }
    $scope.GetProfileDetails();
});



