(function () {
    'use strict';
    var contactAttemptService = angular.module('contactAttemptService', ['ngResource']);
    contactAttemptService.factory('ContactAttempt', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/contactattempt/' + masterProfileId, {}, {
                send: { method: 'POST' }
            });
        }]);
})();