var app = angular.module('MyApp', []);


app.controller('Login', function ($scope, $http, $rootScope) {
    $scope.records = {};
    $scope.sciencerecords = {};
    $scope.password = '';
    $scope.UserId = '';    
    $scope.Password = ''; 
    $scope.Role = '';
    $scope.loginapprove = function () {
         $http({
             method: "GET",
             url: '/ProfilePage/Login',
             params: { RegId: $scope.UserId, PSD: $scope.Password }
         }).then(function mySuccess(response) {
             
            
             var ln = response.data.length;
             if (ln == 0) {
                 alert("Please Check Your UserId/Password OR Your Account Has been Deactivated .");
                 $scope.UserId = "";
                 $scope.Password = "";
             }

             else {
                 
                
                     $scope.Role = response.data[0].Role;
                   
                     if ($scope.Role == "Student") {
                         
                         //$rootScope.GlobalRegId = $scope.UserId;
                         $scope.loginsummery();
                         //$rootScope.$broadcast('SOME_TAG', $scope.UserId);
                         window.location.href = '/ProfilePage/Index';

                     }
                     if ($scope.Role == 'Admin') {
                         $scope.loginsummery();
                         window.location.href = '/UrlupdatePannel/Index';

                     }
                     if ($scope.Role == 'Teacher') {
                         $scope.loginsummery();
                         window.location.href = '/UrlupdatePannel/Index';

                     }
               
             }

         }, function myError(response) {
             $scope.records = response.statusText;
         });
    }


    $scope.GetProfileDetails = function () {
        
        $http({
            method: "GET",
            url: '/ProfilePage/GetProfiledetails',
            params: { RegId: $scope.RegId }
        }).then(function mySuccess(response) {

            $scope.Name = response.data[0].Name;
            $scope.Class = response.data[0].Class;
            $scope.Address = response.data[0].Address;
            $scope.Phone = response.data[0].Phone;

           


           

        }, function myError(response) {
            $scope.Profiledetails = response.statusText;


        });
    }

    $scope.loginsummery = function () {

        //alert($scope.SendingEmail.tostring());
        
        var formdata = new FormData();
        //formdata.append("Comm", JSON.stringify($scope.UserId));
        $http({
            method: "Post",
            url: '/ProfilePage/loginsummery',
            params: { RegId: $scope.UserId },
            headers: { "Content-Type": undefined },
            transformRequest: angular.identity
        }).then(function (d) {
            //alert(d.data);
            
        }, function (Error) {
            alert("Error");
        });

    }

  
  




});