'use strict';
onlineShop.controller("reviewController", function ($scope, $resource, $sce, dataService) {
    $scope.productId = $("#Id").val();
    $scope.userProductReview = { productId: $scope.productId, review: "",rating:0 };
   $scope.isReviewPosted=false;
    $scope.getProductReviews = function () {
        dataService.getProductReviews($scope.productId).then(function (results) {
            $scope.productReviews = results;
        });
    };
    $scope.getProductReviews();
    $scope.submitReview = function () {
        if ($scope.userProductReview.review != '')
        {
            dataService.addProductReview($scope.userProductReview).then(function (results) {
                $scope.productReviews = results;
                $scope.isReviewPosted = true;
                $scope.userProductReview.review = '';
            });
        }
    };
});