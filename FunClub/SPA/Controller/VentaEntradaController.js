angular.module('app').controller("VentaEntradaController", ["$scope", "VentaEntradaService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, VentaEntradaService, ngDialog, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.Entradas = {};
    var EntradasAux = {};

    $scope.Venta = [];

    function GetEntradas() {
        $scope.Cargando = true;
        VentaEntradaService.GetEntradas().then(function (response) {
            $scope.Entradas = response.data;
            EntradasAux = response.data;
            $scope.Cargando = false;

        });
    }

    function EliminarEntradaLista(entrada) {
        for (var i = 0; i < $scope.Entradas.length; i++) {
            if ($scope.Entradas[i].CodEntrada == entrada.CodEntrada) {
                $scope.Entradas.splice(i, 1);
            }
        }
    }

    $scope.Agregar = function (entrada) {
        if (entrada.Cantidad > 0) {
            $scope.Venta.push(entrada);
            entrada.Agregado = true;
            //EliminarEntradaLista(entrada);
        }
    };

    $scope.CancelarTicket = function () {
        $scope.Venta = [];
        GetEntradas();
    }

    GetEntradas();

    $scope.verTicket = function () {
        ngDialog.open({
            template: 'SPA/Views/modalTicketEntrada.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

}]);