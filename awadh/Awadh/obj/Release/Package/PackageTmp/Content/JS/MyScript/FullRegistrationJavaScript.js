
var app = angular.module('MyApp', ['ngFileUpload'])
app.controller('myCtrl', function ($scope, $http,Upload, $timeout) {

    
    $scope.Registration = {};
    $scope.SelectedFiles = {};
    $scope.SendingEmail = {};
    $scope.SendEmail = function () {
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

    $scope.submit = function () { 
        var err = '';
        if ($scope.Registration.Name == undefined || $scope.Registration.Name == "") { err += "Please Check Your Name\n";}
        if ($scope.Registration.Father_Name == undefined || $scope.Registration.Father_Name == "") { err += "Please Check Your Father Name\n" }
        if ($scope.Registration.Mother_Name == undefined || $scope.Registration.Mother_Name == "") { err += "Please Check Your MotherName\n" }
        if ($scope.Registration.Address == undefined || $scope.Registration.Address == "") { err += "Please Check Your Address\n" }
        if ($scope.Registration.Phone == undefined || $scope.Registration.Phone == "") { err += "Please Check Your Phone\n" }
        if ($scope.Registration.Role == undefined || $scope.Registration.Role == "") { err += "Please Check Your Role\n" }
        if ($scope.Registration.Role == "Student") { if ($scope.Registration.Class == undefined || $scope.Registration.Class == "") { err += "Please Check Your Class\n" } }

        //if ($scope.SelectedFiles.lenth <= 0 || $scope.SelectedFiles.lenth == undefined) { err += "Please Check Your Photo\n" }
        if (err.length > 0) {
            alert(err);
        }
        else {



            var formdata = new FormData();
            formdata.append("Comm", JSON.stringify($scope.Registration));
            $http({
                method: "Post",
                url: '/StudentRegistration/submitdata',
                data: formdata,
                headers: { "Content-Type": undefined },
                transformRequest: angular.identity
            }).then(function (d) {
                
                if (d.data != "Successfully done" || d.data == undefined) {
                    $scope.SelectedFiles.newname = d.data;
                    $scope.UploadFile();
                    $scope.Registration = {};
                    alert("SuccessFully Done");
                }


            }, function (Error) {
                alert("Error");
            });
        }

    }
    $scope.UploadFiles = function (files) {

        $scope.SelectedFiles = files;
    }

    $scope.UploadFile = function () {
       
        //$scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/StudentRegistration/Upload/',
                data: {
                    files: $scope.SelectedFiles,
                    newname: $scope.SelectedFiles.newname
                }
            }).then(function (response) {
                $timeout(function () {
                    $scope.Result = response.data;
                    //alert($scope.Result);
                });
            }, function (response) {
                if (response.status > 0) {
                    var errorMsg = response.status + ': ' + response.data;
                    alert(errorMsg);
                }
            }, function (evt) {
                var element = angular.element(document.querySelector('#dvProgress'));
                $scope.Progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
                element.html('<div style="width: ' + $scope.Progress + '%">' + $scope.Progress + '%</div>');
            });
        }
    };
});