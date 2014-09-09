'use strict';

var app = angular.module('app', ['ngRoute']);


app.config(function ($routeProvider, $locationProvider) {

    //$locationProvider.html5Mode(true);

    $routeProvider.when('/login', { templateUrl: 'templates/login.html', controller: 'loginController' });
    /*$routeProvider.when('/', {
        templateUrl: 'templates/home.html', controller: 'homeController',
        resolve: {
            factory: function () {
                alert($rootScopeProvider.accountTypeCode);
                if ($rootScopeProvider.accountTypeCode == "Admin") {
                    $locationProvider.url('/adminHome');
                }
                else if ($rootScopeProvider.accountTypeCode == "Member") {
                    $locationProvider.url('/memberHome');
                }
                else if ($rootScopeProvider.accountTypeCode == "Trainer") {
                    $locationProvider.url('/trainerHome');
                }
            }
        }
    });*/
    $routeProvider.when('/adminHome', { templateUrl: 'templates/adminHome.html', controller: 'adminHomeController' });
    $routeProvider.when('/memberHome', { templateUrl: 'templates/memberHome.html', controller: 'memberHomeController' });
    $routeProvider.when('/memberWorkoutDay/:date', { templateUrl: 'templates/memberWorkoutDay.html', controller: 'memberWorkoutDayController' });
    $routeProvider.when('/memberSchedule', { templateUrl: 'templates/memberSchedule.html', controller: 'memberScheduleController' });
    $routeProvider.when('/memberResults', { templateUrl: 'templates/memberResults.html', controller: 'memberResultsController' });
    $routeProvider.when('/trainerHome', { templateUrl: 'templates/trainerHome.html', controller: 'trainerHomeController' });


    
    $routeProvider.otherwise({ redirectTo: '/' });
});


app.value('globalData', {
    sessionId: null,
    displayName: '',
    pageName: ''
});