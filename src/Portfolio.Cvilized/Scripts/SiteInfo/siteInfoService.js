(function () {
    'use strict';
    var siteInfoService = angular.module('siteInfoService', ['ngResource']);
    siteInfoService.factory('SiteInfo', ['$resource',
        function ($resource) {
            return $resource(apiRootUrl + 'api/siteinfo/' + masterProfileId, {}, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();