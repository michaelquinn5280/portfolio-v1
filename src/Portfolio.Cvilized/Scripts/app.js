(function () {
    'use strict';

    angular.module('portfolioApp', [
        // Angular modules 
        'ngRoute',
        'ngResource',

        // Custom modules 
        'legalService',
        'profileService',
        'greetingService',
        'projectsService',
        'contactInfoService',
        'contactAttemptService',
        'siteInfoService',

        // 3rd Party Modules
        'easypiechart'
    ])
    .config(['$httpProvider', function ($httpProvider, $location) {
        $httpProvider.interceptors.push('portfolioHttpInterceptor');
    }])
    .factory('portfolioHttpInterceptor', ['$location', function ($location) {
        return {
            request: function (config) {
                var apiRootUrl = 'http://cvservices.azurewebsites.net/';
                var host = $location.host();
                if (host == 'localhost') {
                    apiRootUrl = 'http://localhost:3741/';
                }
                config.url = apiRootUrl + config.url;
                return config;
            }
        };
    }]);
})();