(function () {
    'use strict';
    var greetingService = angular.module('greetingService', ['ngResource']);
    greetingService.factory('Greeting', ['$resource',
        function ($resource) {
            return $resource('api/greeting/:profileId', { profileId: '@profileId' }, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();