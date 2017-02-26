'use strict';
var baseUrl = $("base").first().attr("href");
onlineShop.value('config', {
        useBreeze: false,
        serviceBase: baseUrl+'api/dataservice/',
        baseAppUrl: baseUrl + 'app',
        baseUrl: baseUrl
    });