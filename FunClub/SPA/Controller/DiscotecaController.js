angular.module('app').controller("DiscotecaController", ["$scope", "DiscotecaService", 'Excel', '$timeout', 'Upload', "$q", function ($scope, DiscotecaService, Excel, $timeout,Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.NuevaDisco = false;
    $scope.GestionDisco = false;

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.exportToExcel = function (tableId) { // ex: '#my-table'
        $scope.exportHref = Excel.tableToExcel(tableId, 'sheet name');
        $timeout(function () { location.href = $scope.exportHref; }, 100); // trigger download
    }

    

}])