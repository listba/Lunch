LunchWars.factory('RestaurantsApi', [
    '$resource', function($resource) {
        return $resource('api/Restaurants/', {
            'get': { mthod: 'GET', isArray: false }
        });
    }
]);
