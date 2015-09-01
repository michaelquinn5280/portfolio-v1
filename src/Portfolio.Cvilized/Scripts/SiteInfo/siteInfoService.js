(function () {
    'use strict';
    var siteInfoService = angular.module('siteInfoService', ['ngResource']);
    siteInfoService.factory('SiteInfo', ['$resource',
        function ($resource) {
            return $resource('api/siteinfo/:profileId', { profileId: '@profileId' }, {
                query: { method: 'GET', params: {}, isArray: false }
            });
        }]);
})();