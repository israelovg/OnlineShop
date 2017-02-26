'use strict';
onlineShop.factory('dataService', ['$http', '$q', 'config',
        function ($http, $q, config) {
            var dataFactory = {};
            dataFactory.getProductReviews = function (id) {
                return httpGet('getProductReviews', "id=" + id);
            };
            dataFactory.getCategories = function (id) {
                return httpGet('getCategories');
            };
            dataFactory.addProductReview = function (json) {
                return httpPost('addProductReview', json);
            };
            // http get wrapper with promise
            function httpGet(funcName, queryString) {
                if (typeof queryString != "undefined")
                    queryString = "?" + queryString
                else
                    queryString = "";
                utils.showWait();
                var deferred = $q.defer();
                $http.get(config.serviceBase + funcName + queryString, { params: { "_": $.now() } }).success(function (result) {
                    utils.closeWait();
                    deferred.resolve(result);
                }).error(function (error) {
                    utils.closeWaitOnError();
                    deferred.reject(error);
                });
                return deferred.promise;
            }
            function httpPost(funcName, json) {
                utils.showWait();
                var deferred = $q.defer();
                $http({
                    url: config.serviceBase + funcName,
                    dataType: 'json',
                    method: 'POST',
                    data: (typeof json == "undefined" ? {} : JSON.stringify(json)),
                    headers: { "Content-Type": "application/json; charset=UTF-8" }
                })
                .success(function (result) {
                    utils.closeWait();
                    deferred.resolve(result);
                })
                .error(function (error) {
                    utils.closeWaitOnError();
                    deferred.reject(error);
                });
                return deferred.promise;
            }
            return dataFactory;
        } ]);


