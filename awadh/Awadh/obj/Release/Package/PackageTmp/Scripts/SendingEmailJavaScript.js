alert("Hello1");

var myapp = angular.module('myApp', ['naif.base64']);

myapp.controller('myCtrl', function ($scope, $http, $window, $rootScope) {
    alert("Hello");
    $scope.Registration = {};

    $scope.SendingEmail = {};
    $scope.SendEmail = function () {
        
        //alert($scope.SendingEmail.tostring());
        debugger;
        var formdata = new FormData();
        formdata.append("Comm", JSON.stringify($scope.SendingEmail));
        $http({
            method: "Post",
            url: '/SendingMail/submitdata',
            data: formdata,
            headers: { "Content-Type": undefined },
            transformRequest: angular.identity
        }).then(function (d) {
            alert(d.data);
            $scope.SendingEmail = {};

        }, function (Error) {
            alert("Error");
        });

    }

    //---------------------------
    $scope.onLoad = function (e, reader, file, fileList, fileOjects, fileObj) {
        debugger;
        $scope.Registration.ImagePath = fileObj.base64;
        $scope.Registration.ImageLetter = fileObj.filename;
        $scope.Registration.FileType = fileObj.filetype;

    };


    $scope.submit = function () {
        alert('shaktimann');
        debugger;
        var formdata = new FormData();
        formdata.append("Comm", JSON.stringify($scope.Registration));
        $http({
            method: "Post",
            url: '/StudentRegistration/submitdata',
            data: formdata,
            headers: { "Content-Type": undefined },
            transformRequest: angular.identity
        }).then(function (d) {
            alert(d.data);
            $scope.Registration = {};

        }, function (Error) {
            alert("Error");
        });

    }




});