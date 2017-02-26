'use strict';
onlineShop.controller("searchController", function ($scope, $resource, $routeParams, $location, $timeout, dataService, modalService, config) {
    $scope.baseUrl = config.baseUrl;
    $scope.selectedCategory = { id: 0, name: 'Everything' };
    if (utils.queryStringValueByKey("search"))
        $scope.search = utils.queryStringValueByKey("search");
    dataService.getCategories().then(function (results) {
        $scope.categories = results;
        if (utils.queryStringValueByKey("category"))
            $scope.selectCategory(utils.queryStringValueByKey("category"));
    });
    $scope.selectCategory=function(categoeyId)
    {
        $scope.selectedCategory = $scope.categories.filter(function (x) {
            return x.id == categoeyId;
        })[0];
    }
    $scope.searchInputKeyPress = function ($event) {
        var code = $event.keyCode || $event.which;
        if (code === 13)
            $scope.searchClicked();
    }
    $scope.searchClicked=function()
    {
        var searchUrl = $scope.baseUrl + "?";
       
        if ($scope.search) {
            searchUrl = searchUrl + "search=" + $scope.search;
            if ($scope.selectedCategory.id > 0)
                searchUrl = searchUrl + "&category=" + $scope.selectedCategory.id;
            location.href = searchUrl;
        }

    }
});