angular.module("app").factory("PagoService", function ($http, $q) {


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

    return service;

})