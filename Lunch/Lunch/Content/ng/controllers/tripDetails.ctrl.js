// trip = { tripUsers, tripVotes }
// tripUsers = { name, votes, isDriving, didAttend }
// tripVotes = { trip, user, restaurant }

LunchWars.controller('tripDetails',
    ['$scope',
    function ($scope) {
        $scope.trip = {name: "Trip", users: []};
    }]);