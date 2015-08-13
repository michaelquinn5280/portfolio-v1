(function () {
    'use strict';
    var profileService = angular.module('profileService', ['ngResource']);
    profileService.factory('Profile', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/profile/' + masterProfileId, {}, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();