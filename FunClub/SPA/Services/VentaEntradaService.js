angular.module("app").factory("VentaEntradaService", function ($http, $q) {


    var service = {};

    service.ProcesarPago = function (item,mediopago,pago) {
        var promise = $http({
            method: 'post',
            url: '/VentaEntrada/ProcesarPago',
            data: { item: item, pago: pago },
            params: { mediopago: mediopago}
        });

        return $q.when(promise);

    };



    service.GetEntradas = function () {
        var promise = $http({
            method: 'get',
            url: '/VentaEntrada/GetAllEntradas'
        });


        return $q.when(promise);

    };

    service.GetByName = function (item) {
        var promise = $http({
            method: 'get',
            url: '/Product/GetByName',
            params: { name: item }
        });


        return $q.when(promise);

    };

    service.GetAllNames = function () {
        var promise = $http({
            method: 'get',
            url: '/Product/GetAllNames'
        });


        return $q.when(promise);

    };


    service.GetCartByIdClient = function (id) {
        var promise = $http({
            method: 'get',
            url: '/Product/GetCartByIdClient',
            params: {
                id: id
            }
        });

        return $q.when(promise);

    };

    service.AgregarAlCarrito = function (item) {
        var promise = $http({
            method: 'post',
            url: '/Product/AgregarAlCarrito',
            data: { item: item }
        });

        return $q.when(promise);

    };

    service.PublicarProducto = function (file,product) {
        var promise = $http({
            method: 'post',
            url: '/Product/PublicarProducto',
            data: { file: file, product: product}
        });

        return $q.when(promise);

    };

    service.ConfirmarCarrito = function (item) {
        var promise = $http({
            method: 'post',
            url: '/Product/ConfirmarCarrito'
        });

        return $q.when(promise);

    };

    return service;

})