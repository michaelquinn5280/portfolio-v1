(function () {
    'use strict';
    var legalService = angular.module('legalService', ['ngResource']);
    legalService.factory('Copyright', ['$resource',
        function ($resource) {
            return $resource('api/copyright/:profileId', { profileId: '@profileId' }, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();