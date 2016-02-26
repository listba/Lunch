// trip = { tripUsers, tripVotes }
// tripUsers = { name, votes, isDriving, didAttend }
// tripVotes = { trip, user, restaurant }

LunchWars.controller('trips',
    ['$scope', '$state',
    function ($scope, $state) {
        var r1 = { name: "Taco Bell", votes: 31 }
        var r2 = { name: "Chipotle", votes: 24 }
        var r3 = { name: "Dewey's", votes: 8 }
        var trip1 = { name: "trip1", restaurants: [r1, r2, r3], id: 1 }
        var trip2 = { name: 'trip2', restaurants: [ r2, r3, r1 ], id: 2 }

        $scope.trips = [trip1, trip2];

        $scope.goToTripDetails = function(tripId) {
            $state.go('app.tripDetails', { tripId: tripId });
        }
}]);