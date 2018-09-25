angular.module('app').controller("VentaEntradaController", ["$scope", "VentaEntradaService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, VentaEntradaService, ngDialog, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.Entradas = {};

    $scope.Venta = [];

    function GetEntradas() {
        VentaEntradaService.GetEntradas().then(function (response) {
            $scope.Entradas = response.data;

        });
    };

    $scope.Agregar = function (entrada) {
        if (entrada.Cantidad > 0) {
            $scope.Venta.push(entrada);
            entrada = null;
        }
    };

    GetEntradas();

    $scope.verTicket = function () {
        ngDialog.open({
            template: 'SPA/Views/modalTicketEntrada.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

}]);