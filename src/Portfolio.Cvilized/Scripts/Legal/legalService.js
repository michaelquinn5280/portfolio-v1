(function () {
    'use strict';
    var legalService = angular.module('legalService', ['ngResource']);
    legalService.factory('Copyright', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/copyright/' + masterProfileId, {}, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();