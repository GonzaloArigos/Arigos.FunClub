var app = angular.module("app", ['ngRoute', 'ngFileUpload', 'ngDialog', 'htmlToPdfSave']);

app.factory('Excel', function ($window) {
    var uri = 'data:application/vnd.ms-excel;base64,',
        template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
        base64 = function (s) { return $window.btoa(unescape(encodeURIComponent(s))); },
        format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) };
    return {
        tableToExcel: function (tableId, worksheetName) {
            var table = $(tableId),
                ctx = { worksheet: worksheetName, table: table.html() },
                href = uri + base64(format(template, ctx));
            return href;
        }
    };
}),

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/',
        {
            templateUrl: 'SPA/Views/Home.html',
            controller: 'HomeController'
        })
        .when('/Principal',
        {
            templateUrl: 'SPA/Views/Principal.html',
            controller: 'PrincipalController'
        })
        .when('/DiscoManager',
        {
            templateUrl: 'SPA/Views/GestionDiscotecas.html',
            controller: 'DiscotecaController'
        })
        .when('/VentaEntrada',
            {
                templateUrl: 'SPA/Views/VentaEntrada.html',
                controller: 'VentaEntradaController'
            })
        .when('/ProductoManager',
        {
            templateUrl: 'SPA/Views/GestionProductos.html',
            controller: 'ProductoaController'
        })
        .when('/CargaMasiva',
        {
            templateUrl: 'SPA/Views/CargaMasiva.html',
            controller: 'CargaMasivaController'
        })
        .when('/Logoff',
        {
            templateUrl: 'Account/LogOff',
            controller: 'HomeController'
        })
        .otherwise({
            templateUrl: 'SPA/Views/Home.html',
            controller: 'HomeController'
        });


});
