LunchWars
    .factory('RestaurantsApi', [
    '$resource', function($resource) {
        return $resource('api/Restaurants/', {
            'get': { method: 'GET', isArray: true }
        });
    }])
    .factory('UserApi', [
    '$resource', function ($resource) {
        return $resource('api/Users/', {
            'get': { method: 'GET', isArray: false }
        });
    }])
    .factory('TripsApi', [
    '$resource', function ($resource) {
        return $resource('api/Trip/', {
            'get': { method: 'GET', isArray: true }
        });
    }])