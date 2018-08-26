angular.module('app').controller("CargaMasivaController", ["$scope", "CargaMasivaService", 'Upload', "$q", function ($scope, CargaMasivaService, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.DescargarEntradasEjemplo = function () {
        window.location = '/CargaMasiva/DescargarEntradasEjemplo';
    }

    $scope.uploadFiles = function (file, errFiles) {
        $scope.Cargando = true;
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: '/CargaMasiva/CargarEntradas',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $scope.Cargando = false;
                $scope.Ok = true;
                $scope.Resultado = response.data;
            }, function (response) {
                if (response.status > 0)
                    $scope.Cargando = false;
                  //  $scope.errorMsg = response.status + ': ' + response.data;
                $scope.errorMsg = '<b>Error de formato:</b> Por favor verificar que las columnas ingresadas sean correctas y que los tipos de datos ingresados sean los requeridos.';
            }, function (response) {
                file.progress = Math.min(100, parseInt(100.0 *
                    evt.loaded / evt.total));
            });
        }
    }

}])