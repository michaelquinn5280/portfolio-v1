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
    ]);
})();