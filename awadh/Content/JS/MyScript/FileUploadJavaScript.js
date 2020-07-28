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
    $scope.Subjectrecord = {};



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
                url: '/Teacher/ChangeStatus',
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
            $scope.allrecord = response.data;
        }, function myError(response) {
            $scope.Profiledetails = response.statusText;
        });
    }

    $scope.GetProfileDetails = function () {
        $http({
            method: "GET",
            url: '/Common/GetProfiledetails'
            //params: { RegId: $scope.RegId }
        }).then(function mySuccess(response) {
            if (response.data.length > 0) {
                console.log(response.data[0].Role, response.data[0].Name);
                $scope.Name = response.data[0].Name;
                $scope.Class = response.data[0].Class;
                $scope.Address = response.data[0].Address;
                $scope.Phone = response.data[0].Phone;
                $scope.UID = response.data[0].RegId;
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
                url: '/Teacher/Upload/',
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
        var err = '';
        if ($scope.VedioDetails.VedioName == undefined || $scope.VedioDetails.VedioName == "") { err += "Please Check Your Vedio Name\n"; }
        if ($scope.VedioDetails.SubjectId == undefined || $scope.VedioDetails.SubjectId == "") { err += "Please Check Your Subject\n" }
        if ($scope.VedioDetails.VedioForClass == undefined || $scope.VedioDetails.VedioForClass == "") { err += "Please Check Class\n" }
        if ($scope.VedioDetails.VedioTittle == undefined || $scope.VedioDetails.VedioTittle == "") { err += "Please Check Vedio Tittle\n" }
        if ($scope.VedioDetails.VedioUrl == undefined || $scope.VedioDetails.VedioUrl == "") { err += "Please Check VedioUrl\n" }


        //if ($scope.SelectedFiles.lenth <= 0 || $scope.SelectedFiles.lenth == undefined) { err += "Please Check Your Photo\n" }
        if (err.length > 0) {
            alert(err);
        }
        else {
            var formdata = new FormData();
            formdata.append("Comm", JSON.stringify($scope.VedioDetails));
            $http({
                method: "Post",
                url: '/Teacher/VedioDetails',
                data: formdata,
                headers: { "Content-Type": undefined },
                transformRequest: angular.identity
            }).then(function (d) {

                if (d.data == "Successfully done") {
                    $scope.VedioDetails = {};
                    alert("SuccessFully Done");
                }
            }, function (Error) {
                alert("Error");
            });
        }
    }

    $scope.GetSubjectMaster = function () {
        $http({
            method: "GET",
            url: '/Teacher/GetSubjectMaster',
            params: {}
        }).then(function mySuccess(response) {
            if (response.data.length > 0) {
                $scope.Subjectrecord = response.data;
            }
        }, function myError(response) {
            $scope.Profiledetails = response.statusText;
        });
    }

    $scope.GetSubjectMaster();
    $scope.GetProfileDetails();
    $scope.GetAllProfileDetails();

});