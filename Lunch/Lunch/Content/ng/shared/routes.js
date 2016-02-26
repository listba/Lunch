LunchWars.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state('app', {
            abstract: true,
            controller: "app",
            views: {
                "nav": { templateUrl: "../Content/ng/shared/nav.tpl.html" },
                "content": { template: "<div ui-view></div>" }
            }
        })
        .state('app.home', {
            url: '/',
            controller: 'home',
            templateUrl: '../Content/ng/partials/home.tpl.html'
        })
        .state('app.trips', {
            url: '/trips',
            controller: 'trips',
            templateUrl: '../Content/ng/partials/trips.tpl.html'
        });
});