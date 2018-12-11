var app = angular.module("app", ['ngRoute', 'ngFileUpload', 'ngDialog', 'htmlToPdfSave','pascalprecht.translate']);

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
        .when('/VentaBarra',
            {
                templateUrl: 'SPA/Views/VentaBarra.html',
                controller: 'VentaBarraController'
            })
        .when('/ProductoManager',
        {
            templateUrl: 'SPA/Views/GestionProductos.html',
            controller: 'ProductoaController'
        })
        .when('/Consumiciones',
        {
            templateUrl: 'SPA/Views/GestorConsumiciones.html',
            controller: 'ConsumicionController'
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

app.config(function ($translateProvider) {
    $translateProvider.fallbackLanguage('es');
    $translateProvider.registerAvailableLanguageKeys(['en', 'es'], {
        'en_*': 'en',
        'es_*': 'es'
    });
    $translateProvider.translations('en', {
        TITULO_HOME: "Know Funclub!",
        SLOGAN: "The app who come to change the way you manage your pubs!",
        DEMO: "Get your demo!",
        MISION_TITULO: "Our Mision",
        MISION: "We are a company dedicated to providing software services to the entertainment industry. Our main objective is to impose our services in most of the clubs of Capital Federal and the province of Buenos Aires, making our customers feel satisfied not only for the technical part of our products, but also the high power of generating value in their businesses facing the client and, as a result, to seek a notable increase in their economic benefits.",
        VISION_TITULO: "Our vision",
        VISION: "To provide the best software service for entertainment, from the hand of the best professionals in the field, allowing our customers to be satisfied by the quality and ease of use, fulfilling their requirements in a responsible, efficient and profitable way, persisting Our position of leadership in the sector in the long term.",
        FOOTER_REDES: "Follow us on our social networks and find out about new content!",
        TITULO_CONFIG: "Configuration",
        MICUENTA_BTN: "My account",
        SELECT_LANG_BTN: "Select language:",
        MEDIO_PAGO_TITULO: "Payment methods",
        MEDIO_PAGO_TEXTO: "We have different means of payment.",
        APP_BUTTON: "Aplication",
        ACCOUNT_MANAG_BUTTON: "Account management",
        EXIT_BUTTON: "Log off",
        LOG_IN: "Log In",
        BIENVENIDO: "Welcome",
        DASHBOARD: "Dashboard",
        MASIVE_LOAD: "Masive tickets load",
        MIS_DISCO: "My clubs",
        PRODUCT_MANAGER: "Product manager",
        TICKET_MANAGER: "Ticket manager",
        TICKET_SELL: "Tickets sell",
        TICKET_ACTUAL: "Actual sell ticket",
        VER_TICKET_BTN: "See Ticket",
        REINICIAR_VENTA: "Restart sell",
        ULTIMAS_VENTAS: "Last sells",
        VER_CONTENIDO: "See content",
        AGREGAR: "Add",
        CANTIDAD: "Cuantity",
        ENTRADA: "Ticket",
        FACTURACION: "Billing",
        TIEMPO_REAL: "Ticket sales in real time",
        HORASOL: "Hour Sol.",
        MEDIOP: "Paym.M/",
        ESTADO: "State",
        HPAGO: "Paym.Hour",
        EXPORTEXCEL_BTN: "Export to excel",
        TIEMPO_REAL_FICH: "Signs in real time",
        BUTTON_LANG_EN: "English",
        BUTTON_LANG_ES: "Spanish"
    });
    $translateProvider.translations('es', {
        TITULO_HOME: "Conoce FunClub!",
        SLOGAN: "La aplicación que llegó para cambiar la manera que gestionas tus bares/ discotecas!",
        DEMO: "Solicita tu demo!",
        MISION_TITULO: "¿Cuál es nuestra misión?",
        MISION: "Somos una empresa dedicada a brindar servicios de software a la industria del entretenimiento. Nuestro principal objetivo el lograr imponer nuestros servicios en la mayoría de las discotecas de Capital Federal y la provincia de Buenos Aires, logrando que nuestros clientes se sientan satisfechos no solo por la parte técnica de nuestros productos, sino que también el alto poder de generar valor en sus negocios de cara al cliente y, como resultado, procurar un notable incremento en sus beneficios económicos.",
        VISION_TITULO: "¿A qué apuntamos?",
        VISION: "Brindar el mejor servicio de software para entretenimientos, de la mano de los mejores profesionales en el rubro, permitiendo que nuestros clientes se vean satisfechos por la calidad y facilidad de uso, cumpliendo los requerimientos de los mismos en forma responsable, eficiente y rentable, persistiendo nuestra posición de liderazgo en el sector a largo plazo.",
        FOOTER_REDES: "Siguenos en nuestras redes sociales y enterate de nuevos contenidos!",
        TITULO_CONFIG: "Configuración",
        MICUENTA_BTN: "Mi cuenta",
        SELECT_LANG_BTN: "Seleccionar idioma:",
        MEDIO_PAGO_TITULO: "Medios de pago",
        MEDIO_PAGO_TEXTO: "Contamos con diversos medios de pago.",
        APP_BUTTON: "Aplicación",
        ACCOUNT_MANAG_BUTTON: "Gestión de cuenta",
        EXIT_BUTTON: "Salir",
        LOG_IN: "Acceso clientes",
        BIENVENIDO: "Bienvenido",
        DASHBOARD: "Dashboard",
        MASIVE_LOAD: "Carga masiva",
        MIS_DISCO: "Mis discotecas",
        PRODUCT_MANAGER: "Produtos",
        TICKET_MANAGER: "Entradas",
        TICKET_SELL: "Venta entradas",
        TICKET_ACTUAL: "Ticket actual",
        VER_TICKET_BTN: "Ver ticket",
        REINICIAR_VENTA: "Reiniciar venta",
        ULTIMAS_VENTAS: "Ultimas ventas",
        VER_CONTENIDO: "Ver contenido",
        AGREGAR: "Agregar",
        CANTIDAD: "Cantidad",
        ENTRADA: "Entrada",
        FACTURACION: "Facturación",
        TIEMPO_REAL: "Venta de entradas en tiempo real",
        HORASOL: "Hora Sol.",
        MEDIOP: "Medio.P/",
        ESTADO: "Estado",
        HPAGO: "Hora pago",
        EXPORTEXCEL_BTN: "Exportar excel",
        TIEMPO_REAL_FICH: "Fichadas en tiempo real",
        BUTTON_LANG_EN: "Inglés",
        BUTTON_LANG_ES: "Español"
    });
    $translateProvider.useSanitizeValueStrategy('escape');
    $translateProvider.preferredLanguage('es');

});
app.controller('Ctrl', ['$scope', '$translate', function ($scope, $translate) {
    $scope.changeLanguage = function (key) {
        $translate.use(key);
    };
}]);
