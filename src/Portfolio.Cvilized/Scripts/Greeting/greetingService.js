(function () {
    'use strict';
    var greetingService = angular.module('greetingService', ['ngResource']);
    greetingService.factory('Greeting', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/greeting/' + masterProfileId, {}, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();