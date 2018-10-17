angular.module('app').controller("VentaEntradaController", ["$scope", "VentaEntradaService", "PagoService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, VentaEntradaService, PagoService, ngDialog, Excel, $timeout, Upload, $q) {



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
        $scope.ErrorPago = '';
        $scope.Imprimir = false;

        $scope.NumeroDocumento = "";
        $scope.TarjetaNro = "";
        $scope.CodigoSeguridad = "";
        $scope.FechaVencimiento = "";


        $scope.Entradas = {};
        $scope.EntradasHoy = {};

        var EntradasAux = {};

        $scope.Venta = [];

        $scope.SubTotal = 0;
        $scope.MontoEfectivoPagado = 0;
        ngDialog.close();
        GetEntradas();
    }

    $scope.Inicializar();

    $scope.ProcesarPago = function (montoEfectivoPag, efec, tdbb, tccc, nrodoc, tjnro, codseg, fvenc) {


        var detalleVenta = [];

        for (var i = 0; i < $scope.Venta.length; i++) {
            var detalle = {
                CodEntrada: $scope.Venta[i].CodEntrada,
                Cantidad: $scope.Venta[i].Cantidad
            };
            detalleVenta.push(detalle);
        }


        var pago = {};


        if (efec) {
            pago.MontoPagado = montoEfectivoPag;
            pago.Vuelto = montoEfectivoPag - $scope.SubTotal;
            if (pago.Vuelto >= 0) {
                $scope.CargandoPago = true;
                PagoService.ProcesarPago(JSON.stringify(detalleVenta), 1, JSON.stringify(pago)).then(function (response) {
                    $scope.CargandoPago = false;
                    $scope.EfectivoConfirmado = true;
                });
            } else {
                $scope.ErrorPago = 'El monto ingresado debe ser superior al total.';
            }
        }

        if (tdbb) {

            if (nrodoc.length == 0 || tjnro.length == 0 || codseg.length == 0 || fvenc.length == 0) {
                $scope.ErrorPago = 'Debe ingresar todos los campos para continuar.';

            }

            if ($scope.ErrorPago == '') {
                pago.NumeroDocumento = nrodoc;
                pago.TarjetaNro = tjnro;
                pago.CodigoSeguridad = codseg;
                pago.FechaVencimiento = "01/" + fvenc;
                $scope.CargandoPago = true;
                PagoService.ProcesarPago(JSON.stringify(detalleVenta), 2, JSON.stringify(pago)).then(function (response) {
                    $scope.CargandoPago = false;
                    $scope.PagoTarjetaOk = true;
                });
            }
        }
    }

    function GetEntradas() {
        $scope.Cargando = true;
        VentaEntradaService.GetEntradas().then(function (response) {
            $scope.Entradas = response.data;
            EntradasAux = response.data;
            $scope.Cargando = false;

        });

        VentaEntradaService.GetVentaEntradasHoy(5).then(function (response) {
            $scope.EntradasHoy = response.data;
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

    $scope.CancelarVenta = function (x) {
        VentaEntradaService.CancelarVenta(x.CodVentaEntrada, x.CodDiscoteca).then(function (response) {
            x.Estado = 2;
        });
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

    $scope.verEntradasHoy = function () {
        ngDialog.open({
            template: 'SPA/Views/modalEntradasHoy.html',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

}]);