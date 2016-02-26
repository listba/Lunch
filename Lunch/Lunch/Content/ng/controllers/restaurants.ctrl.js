LunchWars.controller('restaurants',
    ['$scope', 'RestaurantsApi',
    function ($scope, restaurantsApi) {
        restaurantsApi.get(function(data) {
            $scope.restaurants = data
        });
}]);