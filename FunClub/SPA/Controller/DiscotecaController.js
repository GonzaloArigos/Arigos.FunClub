angular.module('app').controller("DiscotecaController", ["$scope", "DiscotecaService", 'Excel', '$timeout', 'Upload', "$q", function ($scope, DiscotecaService, Excel, $timeout,Upload, $q) {

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

        if ($scope.UsuarioSeleccionado){
        var permisos = $scope.UsuarioSeleccionado.AspNetRoles;        
        for (var i = 0; i < permisos.length; i++) {

            if (permisos[i].Id == 1){
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

    $scope.GetDiscotecas();

    $scope.exportToExcel = function (tableId) { // ex: '#my-table'
        $scope.exportHref = Excel.tableToExcel(tableId, 'sheet name');
        $timeout(function () { location.href = $scope.exportHref; }, 100); // trigger download
    }

    

}])