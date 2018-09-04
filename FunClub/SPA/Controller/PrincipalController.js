angular.module('app').controller("PrincipalController", ["$scope", "PrincipalService", 'Upload', "$q", function ($scope, PrincipalService, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;


}])