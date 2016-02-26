LunchWars.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state('app', {
            abstract: true,
            controller: "app",
            views: {
                "nav": { templateUrl: "../Content/ng/shared/nav.tpl.html" },
                "content": { template: "<div class='app-container'><div ui-view></div></div>" }
            }
        })
        .state('app.trips', {
            url: '/',
            controller: 'trips',
            templateUrl: '../Content/ng/partials/trips.tpl.html'
        })
        .state('app.createTrip', {
            url: '/trips/create',
            controller: 'createTrip',
            templateUrl: '../Content/ng/partials/create-trip.tpl.html'
        })
        .state('app.tripDetails', {
            url: '/trips/:tripId',
            controller: 'tripDetails',
            templateUrl: '../Content/ng/partials/trip-details.tpl.html'
        })
        .state('app.login', {
            url: '/login',
            controller: 'login',
            templateUrl: '../Content/ng/partials/login.tpl.html'
        })
        .state('app.register', {
            url: '/register',
            controller: 'register',
            templateUrl: '../Content/ng/partials/register.tpl.html'
        })
        .state('app.restaurants', {
            url: '/restaurants',
            controller: 'restaurants',
            templateUrl: '../Content/ng/partials/restaurants.tpl.html'
        })
        .state('app.profile', {
            url: '/profile',
            controller: 'profile',
            templateUrl: '../Content/ng/partials/profile.tpl.html'
        });
});