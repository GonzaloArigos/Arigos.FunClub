angular.module('app').controller("VentaEntradaController", ["$scope", "VentaEntradaService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, VentaEntradaService, ngDialog, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.Continuar = false;
    $scope.Efectivo = true;
    $scope.TD = false;
    $scope.TC = false;

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;
    $scope.EntradaSeleccionada = {};
    $scope.CargandoPago = false;
    $scope.EfectivoConfirmado = false;

    $scope.Entradas = {};

    var EntradasAux = {};

    $scope.Venta = [];

    $scope.SubTotal = 0;
    $scope.MontoEfectivoPagado = 0;

    //.---------------------
    $scope.Inicializar = function () {
        $scope.Cargando = false;
        $scope.Ok = false;
        $scope.Resultado = [];

        $scope.Continuar = false;
        $scope.Efectivo = true;
        $scope.TD = false;
        $scope.TC = false;

       
        $scope.VerCorrectos = false;
        $scope.VerEx = false;
        $scope.VerErr = false;
        $scope.EntradaSeleccionada = {};
        $scope.CargandoPago = false;
        $scope.EfectivoConfirmado = false;

        $scope.Entradas = {};

        var EntradasAux = {};

        $scope.Venta = [];

        $scope.SubTotal = 0;
        $scope.MontoEfectivoPagado = 0;
        ngDialog.close();
        GetEntradas();
    }

    $scope.ProcesarPago = function (montoEfectivoPag) {
      
        $scope.CargandoPago = true;
        var detalleVenta = [];

        for (var i = 0; i < $scope.Venta.length; i++) {
            var detalle = {
                CodEntrada: $scope.Venta[i].CodEntrada,
                Cantidad: $scope.Venta[i].Cantidad
            };
            detalleVenta.push(detalle);
        }
       

        var pago = {};

        $scope.MontoEfectivoPagado;

        if ($scope.Efectivo) {
            pago.MontoPagado = montoEfectivoPag;
            pago.vuelto = montoEfectivoPag - $scope.SubTotal;
        }

        VentaEntradaService.ProcesarPago(JSON.stringify(detalleVenta), 1, JSON.stringify(pago)).then(function (response) {
            $scope.CargandoPago = false;
            $scope.EfectivoConfirmado = true;
        });

    
    }

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

    $scope.CalcularSubTotalVenta = function (cantidad, precio) {
        $scope.SubTotal = $scope.SubTotal + (cantidad * precio);
    }

    $scope.CancelarTicket = function () {
        $scope.Venta = [];
        $scope.SubTotal = 0;
        GetEntradas();
    }

    $scope.Seleccionar = function (entrada) {
        $scope.EntradaSeleccionada = entrada;
    }

    GetEntradas();

    $scope.verTicket = function () {
        ngDialog.open({
            template: 'SPA/Views/modalTicketEntrada.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

    $scope.verEntrada = function () {
        ngDialog.open({
            template: 'SPA/Views/modalDetalleEntrada.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

}]);