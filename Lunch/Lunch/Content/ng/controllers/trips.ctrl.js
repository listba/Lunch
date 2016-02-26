// trip = { tripUsers, tripVotes }
// tripUsers = { name, votes, isDriving, didAttend }
// tripVotes = { trip, user, restaurant }

LunchWars.controller('trips', 
    ['$scope', '$state', 'TripsApi',
    function ($scope, $state, tripsApi) {

        tripsApi.get({}, function (data) {
            console.log(data);
            $scope.trips = data;
        });

        $scope.goToTripDetails = function(tripId) {
            $state.go('app.tripDetails', { tripId: tripId });
        }

        $scope.joinTrip = function(tripId) {
            tripsApi.post({ tripId: tripId }, function(data) {

            });
        }
}]);