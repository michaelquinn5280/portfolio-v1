(function () {
    'use strict';
    var profileService = angular.module('profileService', ['ngResource']);
    profileService.factory('Profile', ['$resource',
    function ($resource) {
        return $resource('api/profile/:profileId', { profileId: '@profileId' }, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    }]);
    profileService.factory('ProfileReference', ['$resource',
        function ($resource) {
            return $resource('api/profileId/', { }, {
                query: { method: 'GET', params: { reference: '@reference' }, isArray: false }
            });
        }]);
})();