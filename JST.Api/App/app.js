'use strict';

var app = angular.module('app', ['ngRoute']);


app.config(function ($routeProvider, $locationProvider) {

   // $locationProvider.html5Mode(true);

    $routeProvider.when('/login', { templateUrl: 'templates/login.html', controller: 'loginController' });

    $routeProvider.when('/adminHome', { templateUrl: 'templates/adminHome.html', controller: 'adminHomeController' });

    $routeProvider.when('/competitorWorkoutDay', { templateUrl: 'templates/competitorWorkoutDay.html', controller: 'competitorWorkoutDayController' });
    $routeProvider.when('/competitorSchedule', { templateUrl: 'templates/competitorSchedule.html', controller: 'competitorScheduleController' });
    $routeProvider.when('/competitorResults', { templateUrl: 'templates/competitorResults.html', controller: 'competitorResultsController' });
    $routeProvider.when('/competitorMyResults', { templateUrl: 'templates/competitorMyResults.html', controller: 'competitorMyResultsController' });

    $routeProvider.when('/trainerHome', { templateUrl: 'templates/trainerHome.html', controller: 'trainerHomeController' });


    $routeProvider.when('/testing', { templateUrl: 'templates/testing.html', controller: 'testingController' });


    
    $routeProvider.otherwise({ redirectTo: '/' });
});


app.value('globalData', {
    sessionId: null,
    displayName: '',
    pageName: ''
});