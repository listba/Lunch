LunchWars
    .factory('RestaurantsApi', [
        '$resource', function($resource) {
            return $resource('api/Restaurants/', {}, { 'get': { isArray: true } });
        }
    ])
    .factory('UserApi', [
        '$resource', function($resource) {
            return $resource('api/Users/', {});
        }
    ])
    .factory('TripsApi', [
        '$resource', function($resource) {
            return $resource('api/Trip/', {}, { 'get': { isArray: true } });
        }
    ]);