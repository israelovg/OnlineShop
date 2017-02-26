'use strict';
onlineShop.controller("productListController", function ($scope, $resource, $sce, dataService, config, $http) {
    $scope.baseUrl = config.baseUrl;
    $scope.loadMoreDisabled = false;
    $scope.page = 1;
    $scope.search = utils.queryStringValueByKey("search");
    $scope.category = utils.queryStringValueByKey("category");
    $scope.loadMore = function () {

        var loadMoreUrl = $scope.baseUrl + "catalog/loadMore?page=" + $scope.page;
        if ($scope.search) 
            loadMoreUrl = loadMoreUrl + "&search=" + $scope.search;
           
        if ($scope.category)
            loadMoreUrl = loadMoreUrl + "&category=" + $scope.category;

        $http.get(loadMoreUrl).success(function (result) {
            if (result == "")
                $scope.loadMoreDisabled = true;
             $(result).appendTo(".catContent >.row");
         });
         $scope.page++;
        //resource.get(function (value) {
        //    $scope.example4 = value;
        //});
    };
});