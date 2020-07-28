var app = angular.module('MyApp', ['ngFileUpload'])
app.controller('FileUpload', function ($scope, $http, Upload, $timeout) {
    $scope.ChangeStatus = {};
    $scope.records = {};
    $scope.VedioDetails = {};
    $scope.password = '';
    $scope.UserId = '';
    $scope.Password = '';
    $scope.Role = '';
    $scope.SelectedFiles = {};
    $scope.Name = "";
    $scope.Class = "";
    $scope.UID = "";
    $scope.allrecord = {};
   


    $scope.ChangeStatusActive = function () {
        var err = '';
        if ($scope.ChangeStatus.RegId == undefined || $scope.ChangeStatus.RegId == "") { err += "Please Check Id\n" }
        if ($scope.ChangeStatus.Status == undefined || $scope.ChangeStatus.Status == "") { err += "Please Check Status\n" }
        if (err.length > 0) {
            alert(err);
        }
        else {
        $http({
            method: "GET",
            url: '/ChangeStatusPannel/ChangeStatus',
            params: { RegId: $scope.ChangeStatus.RegId, Status: $scope.ChangeStatus.Status }
        }).then(function mySuccess(response) {
            $scope.records = response.data;
            alert($scope.records);
            $scope.ChangeStatus = {};

        }, function myError(response) {
            $scope.records = response.statusText;
        });
    }
    }
    
    $scope.GetAllProfileDetails = function () {
        $http({
            method: "GET",
            url: '/Common/GetAllProfileDetails',
            params: { RegId: $scope.RegId }
        }).then(function mySuccess(response) {

            if (response.data.length > 0) {
                $scope.allrecord = response.data;
            }
            else {
                // window.location.href = '/Login/Index';
            }
        }, function myError(response) {
            $scope.Profiledetails = response.statusText;
        });
    }    

    $scope.GetProfileDetails = function () {
        $http({
            method: "GET",
            url: '/Common/GetProfiledetails',
            params: { RegId: $scope.RegId }
        }).then(function mySuccess(response) {

            if (response.data.length > 0) {               
                if (response.data[0].Role == 'Admin' || response.data[0].Name == 'Teacher') {
                    $scope.Name = response.data[0].Name;
                    $scope.Class = response.data[0].Class;
                    $scope.Address = response.data[0].Address;
                    $scope.Phone = response.data[0].Phone;
                    $scope.UID = response.data[0].RegId;
                }
                else {
                    window.location.href = '/Login/Index';
                }
            }
            else {
                window.location.href = '/Login/Index';
            }
        }, function myError(response) {
            $scope.Profiledetails = response.statusText;
        });
    }

    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
    }

    $scope.UploadFile = function () {
        $scope.SelectedFiles.newname = $scope.VedioDetails.PDFTITLE;
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
                    $scope.VedioDetails = {};
                    alert($scope.Result);
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

    $scope.submit = function () {
        var formdata = new FormData();
        formdata.append("Comm", JSON.stringify($scope.VedioDetails));
        $http({
            method: "Post",
            url: '/UrlupdatePannel/VedioDetails',
            data: formdata,
            headers: { "Content-Type": undefined },
            transformRequest: angular.identity
        }).then(function (d) {
           
            if (d.data == "Successfully done" ) {
                $scope.VedioDetails = {};
                alert("SuccessFully Done");
            }
        }, function (Error) {
            alert("Error");
        });
    }

    $scope.logout = function () {
        $http({
            method: "GET",
            url: '/Common/logout',
            params: {}
        }).then(function mySuccess(response) {
            $scope.UserId = '';
            $scope.Password = '';
            window.location.href = '/Login/Index';
        }, function myError(response) {
            $scope.records = response.statusText;
        });
    }    

    $scope.GetProfileDetails();
    $scope.GetAllProfileDetails(); 
});