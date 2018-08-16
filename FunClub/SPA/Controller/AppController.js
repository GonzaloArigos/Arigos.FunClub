var app = angular.module("app", ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/',
        {
            templateUrl: 'SPA/Views/Home.html',
            controller: 'HomeController'
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
