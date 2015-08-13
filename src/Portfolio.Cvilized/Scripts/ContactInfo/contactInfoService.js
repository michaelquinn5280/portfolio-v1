(function () {
    'use strict';
    var contactInfoService = angular.module('contactInfoService', ['ngResource']);
    contactInfoService.factory('ContactInfo', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/contactinfo/' + masterProfileId, {}, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();