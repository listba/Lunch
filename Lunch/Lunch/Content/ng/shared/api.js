var api = angular.module('LunchWars.Api', []);

api.factory('RestaurantApi', [
    '$resource', function($resource) {
        $resource('api/Restaurants/');
    }
]);
