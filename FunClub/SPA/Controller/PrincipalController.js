angular.module('app').controller("PrincipalController", ["$scope", "PrincipalService", 'Excel', '$timeout', 'Upload', "$q", function ($scope, PrincipalService, Excel, $timeout, Upload, $q) {

    $scope.Cargando = false;
    $scope.Ok = false;
    $scope.Resultado = [];

    $scope.VerCorrectos = false;
    $scope.VerEx = false;
    $scope.VerErr = false;

    $scope.GetDashboard = function () {
        PrincipalService.GetDashboard().then(function (response) {
            $scope.Dashboard = response.data;
        });
    }

    $scope.GetDashboard();

    setInterval(function () { $scope.GetDashboard(); }, 7000); // Time in milliseconds

    $scope.exportToExcel = function (tableId) { // ex: '#my-table'
        $scope.exportHref = Excel.tableToExcel(tableId, 'sheet name');
        $timeout(function () { location.href = $scope.exportHref; }, 100); // trigger download
    }

}])