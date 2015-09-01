(function () {
    'use strict';
    var contactInfoService = angular.module('contactInfoService', ['ngResource']);
    contactInfoService.factory('ContactInfo', ['$resource',
        function ($resource) {
            return $resource('api/contactinfo/:profileId', { profileId: '@profileId' }, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();