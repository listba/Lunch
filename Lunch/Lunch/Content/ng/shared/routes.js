LunchWars.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state('home', {
            url: "/",
            templateUrl: "../Content/ng/partials/home.tpl.html",
            controller: "home"
        });
});