(function () {
    'use strict';
    var contactAttemptService = angular.module('contactAttemptService', ['ngResource']);
    contactAttemptService.factory('ContactAttempt', ['$resource',
        function ($resource) {
            return $resource('api/contactattempt/:profileId', { profileId: '@profileId' }, {
                send: { method: 'POST' }
            });
        }]);
})();