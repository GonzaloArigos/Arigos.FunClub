angular.module("app").factory("ConsumicionService", function ($http, $q) {


    var service = {};



    service.GetConsumiciones = function () {
        var promise = $http({
            method: 'get',
            url: '/Consumicion/GetAllFromDisco'
        });


        return $q.when(promise);

    };

    service.GetProductos = function () {
        var promise = $http({
            method: 'get',
            url: '/Productoes/GetProductosDisco'
        });


        return $q.when(promise);

    };

   

    service.NuevaConsumicion = function (consumicion) {
        var promise = $http({
            method: 'post',
            url: '/Consumicion/NuevaConsumicion',
            data: { consumicion: consumicion }
        });

        return $q.when(promise);

    };

    service.EditarConsumicion = function (consumicion) {
        var promise = $http({
            method: 'post',
            url: '/Consumicion/EditarConsumicion',
            data: { consumicion: consumicion }
        });

        return $q.when(promise);

    };

    service.AsignarRol = function (roleid, email) {
        var promise = $http({
            method: 'post',
            url: '/Discoteca/AsignarRol',
            params: { roleid: roleid, email: email }
        });

        return $q.when(promise);

    };
    service.EliminarRol = function (roleid, email) {
        var promise = $http({
            method: 'post',
            url: '/Discoteca/EliminarRol',
            params: { roleid: roleid, email: email }
        });

        return $q.when(promise);

    };
    

    service.EditarDisco = function (cod, nombre,prod) {
        var promise = $http({
            method: 'post',
            url: '/Discoteca/EditarDisco',
            params: { cod: cod, nombre: nombre, prod: prod }
        });

        return $q.when(promise);

    };

    service.PublicarProducto = function (file, product) {
        var promise = $http({
            method: 'post',
            url: '/Product/PublicarProducto',
            data: { file: file, product: product }
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