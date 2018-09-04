var app = angular.module("app", ['ngRoute', 'ngFileUpload']);

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
