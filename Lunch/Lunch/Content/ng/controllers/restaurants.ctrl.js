LunchWars.controller('restaurants',
    ['$scope', 'RestaurantsApi',
    function ($scope, restaurantsApi) {
        restaurantsApi.get({zip: 45242}, function(data) {
            $scope.restaurants = data.businesses;
        });
}]);