'use strict';

var app = angular.module('app', ['ngRoute', 'angular-loading-bar']);


app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    //can't use this as it breaks accountEdit
    //$locationProvider.html5Mode(true);

    $routeProvider.when('/login', { templateUrl: 'templates/login.html', controller: 'loginController' });
    $routeProvider.when('/contact', { templateUrl: 'templates/contact.html', controller: 'contactController' });

    $routeProvider.when('/adminHome', { templateUrl: 'templates/adminHome.html', controller: 'adminHomeController' });

    $routeProvider.when('/competitorWorkoutDay', { templateUrl: 'templates/competitorWorkoutDay.html', controller: 'competitorWorkoutDayController' });
    $routeProvider.when('/competitorSchedule', { templateUrl: 'templates/competitorSchedule.html', controller: 'competitorScheduleController' });
    $routeProvider.when('/competitorResults', { templateUrl: 'templates/competitorResults.html', controller: 'competitorResultsController' });
    $routeProvider.when('/competitorMyResults', { templateUrl: 'templates/competitorMyResults.html', controller: 'competitorMyResultsController' });

    $routeProvider.when('/trainerSchedule', { templateUrl: 'templates/trainerSchedule.html', controller: 'trainerScheduleController' });
    $routeProvider.when('/accountList', { templateUrl: 'templates/accountList.html', controller: 'accountListController' });
    $routeProvider.when('/accountEdit/:accountId?', { templateUrl: '/templates/accountEdit.html', controller: 'accountEditController' });

    $routeProvider.otherwise({ redirectTo: '/' });

    $httpProvider.interceptors.push('httpInterceptorService');
});

app.value('globalData', {
    sessionId: null,
    displayName: '',
    pageName: '',
    message: null
});