angular.module("app").factory("ProductoService", function ($http, $q) {


    var service = {};



    service.GetDiscotecasUsuario = function () {
        var promise = $http({
            method: 'get',
            url: '/Discoteca/GetDiscotecasUsuario'
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

    service.NuevaDiscoteca = function (nombre) {
        var promise = $http({
            method: 'post',
            url: '/Discoteca/NuevaDiscoteca',
            params: { nombre: nombre }
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