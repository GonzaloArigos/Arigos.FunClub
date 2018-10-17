angular.module("app").factory("WhatsappService", function ($http, $q) {


    var service = {};

    service.EnviarMensaje = function (mensajewsp) {
        var promise = $http({
            method: 'post',
            url: '/Whatsapp/EnviarMensaje',
            params: { mensajewsp: mensajewsp}
        });

        return $q.when(promise);

    };   

    return service;

})