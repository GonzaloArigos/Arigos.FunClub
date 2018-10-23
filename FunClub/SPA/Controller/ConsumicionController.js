angular.module('app').controller("ConsumicionController", ["$scope", "ConsumicionService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, ConsumicionService, ngDialog, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.NuevaDisco = false;
    $scope.GestionDisco = false;

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.ConsumicionSeleccionada = {};
    $scope.ProductoSeleccionado = {};

    $scope.SeleccionarConsumicion = function (x) {
        $scope.ConsumicionSeleccionada = x;
    }

    $scope.GetConsumiciones = function () {

        ConsumicionService.GetConsumiciones().then(function (response) {
            if (response.data.length > 0) {
                $scope.Consumiciones = [];
                $scope.Consumiciones = response.data;
            }

        });
    }

    $scope.GetProductos = function () {

        ConsumicionService.GetProductos().then(function (response) {
            if (response.data.length > 0) {
                $scope.Productos = [];
                $scope.Productos = response.data;
            }

        });
    }



    $scope.GetConsumiciones();
    $scope.GetProductos();

    $scope.AgregarProducto = function (producto, cantidad) {
        if (producto && cantidad > 0) {
            var consumicion_bebida = {
                Producto: producto,
                CodBebida: producto.CodBebida,
                Cantidad: cantidad
            }
            $scope.ConsumicionSeleccionada.Consumicion_Bebida.push(consumicion_bebida);
        }
    }


    $scope.AgregarUsuario = function (email, disco) {
        var usuario_nuevo = { EmailUsuario: email, CodDiscoteca: disco };
        $scope.DiscotecaSeleccionada.Usuario_Discotecas.push(usuario_nuevo);
    }

    $scope.EliminarProducto = function (x) {
        for (var i = 0; i < $scope.ConsumicionSeleccionada.Consumicion_Bebida.length; i++) {
            if ($scope.ConsumicionSeleccionada.Consumicion_Bebida[i].CodBebida == x.CodBebida) {
                $scope.ConsumicionSeleccionada.Consumicion_Bebida.splice(i, 1);
            }
        }
    }

    $scope.Confirmar = function () {
        if ($scope.Nuevo) {

            ConsumicionService.NuevaConsumicion(JSON.stringify($scope.ConsumicionSeleccionada)).then(function (response) {
                $scope.GetConsumiciones();
                ngDialog.close();
                $scope.ConsumicionSeleccionada = {};
            });

        }
    }

    $scope.GenerarNuevo = function () {
        $scope.Nuevo = true;
        $scope.Editar = false;
        $scope.ConsumicionSeleccionada = { Consumicion_Bebida: [], Descripcion: '' }
    }

    $scope.GenerarEditar = function () {
        $scope.Editar = true;
        $scope.Nuevo = false;
    }


    $scope.VerConsumicion = function () {
        ngDialog.open({
            template: 'SPA/Views/modalEditarConsumicion.html',
            className: 'ngdialog-theme-default',
            scope: $scope,

        });
    };



}])