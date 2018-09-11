angular.module('app').controller("DiscotecaController", ["$scope", "DiscotecaService", "ngDialog", 'Excel', '$timeout', 'Upload', "$q", function ($scope, DiscotecaService, ngDialog, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.NuevaDisco = false;
    $scope.GestionDisco = false;

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.DiscotecaSeleccionada = [];
    $scope.UsuarioSeleccionado = [];

    $scope.GetDiscotecas = function () {

        DiscotecaService.GetDiscotecasUsuario().then(function (response) {
            $scope.Discotecas = response.data;
            $scope.DiscotecaSeleccionada = response.data[0];
            $scope.UsuarioSeleccionado = $scope.DiscotecaSeleccionada.Usuario_Discotecas[0].AspNetUser;
            $scope.VerificarPermisos();
        });
    }

    $scope.VerificarPermisos = function () {
        $scope.Administrador = false;
        $scope.CajeroBar = false;
        $scope.CajeroEntrada = false;
        $scope.GestorEntrada = false;
        $scope.GestorConsumicion = false;

        if ($scope.UsuarioSeleccionado) {
            var permisos = $scope.UsuarioSeleccionado.AspNetRoles;
            for (var i = 0; i < permisos.length; i++) {

                if (permisos[i].Id == 1) {
                    $scope.Administrador = true;
                }
                if (permisos[i].Id == 2) {
                    $scope.CajeroBar = true;
                }
                if (permisos[i].Id == 3) {
                    $scope.CajeroEntrada = true;
                }
                if (permisos[i].Id == 4) {
                    $scope.GestorEntrada = true;
                }
                if (permisos[i].Id == 5) {
                    $scope.GestorConsumicion = true;
                }
            }

        }
    }
    $scope.NuevaDiscotecaNombre = "";

    $scope.GuardarNuevaDisco = function () {

        DiscotecaService.NuevaDiscoteca($scope.NuevaDiscotecaNombre).then(function (response) {
            $scope.GetDiscotecas();
            $scope.Ok = true;
        });
    }

    $scope.GetDiscotecas();

    $scope.exportToExcel = function (tableId) { // ex: '#my-table'
        $scope.exportHref = Excel.tableToExcel(tableId, 'sheet name');
        $timeout(function () { location.href = $scope.exportHref; }, 100); // trigger download
    }

    $scope.NuevoUsuario = "";

    $scope.AgregarUsuario = function (email, disco) {
        var usuario_nuevo = { EmailUsuario: email, CodDiscoteca: disco };
        $scope.DiscotecaSeleccionada.Usuario_Discotecas.push(usuario_nuevo);
    }

    $scope.EliminarUsuario = function (email) {
        for (var i = 0; i < $scope.DiscotecaSeleccionada.Usuario_Discotecas.length; i++) {
            if ($scope.DiscotecaSeleccionada.Usuario_Discotecas[i].EmailUsuario == email) {
                $scope.DiscotecaSeleccionada.Usuario_Discotecas.splice(i, 1);
            }
        }
    }

    $scope.AsignarRol = function (cod) {
        DiscotecaService.AsignarRol(cod,$scope.UsuarioSeleccionado.Email).then(function (response) {
            var rolnuevo = { Id: cod };
            $scope.UsuarioSeleccionado.AspNetRoles.push(rolnuevo);
            $scope.VerificarPermisos();
        });
    }

    $scope.EliminarRol = function (cod) {
        DiscotecaService.EliminarRol(cod, $scope.UsuarioSeleccionado.Email).then(function (response) {
            var rolnuevo = { Id: cod };
            $scope.UsuarioSeleccionado.AspNetRoles.push(rolnuevo);
            $scope.VerificarPermisos();
        });
    }

    $scope.SolicitudEditar = function () {
        DiscotecaService.EditarDisco($scope.DiscotecaSeleccionada.CodDiscoteca, $scope.DiscotecaSeleccionada.Descripcion, $scope.DiscotecaSeleccionada.Productiva).then(function (response) {
            var aux = $scope.DiscotecaSeleccionada;
            $scope.GetDiscotecas();
            ngDialog.close();
            $scope.DiscotecaSeleccionada = aux;
        });
    }

    $scope.editarDisco = function () {
        ngDialog.open({
            template: 'SPA/Views/modalEditarDisco.html',
            className: 'ngdialog-theme-default',
            scope: $scope,

        });
    };



}])