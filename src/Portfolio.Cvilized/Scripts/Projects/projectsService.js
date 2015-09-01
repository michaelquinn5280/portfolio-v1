(function () {

    'use strict';

    var projectsService = angular.module('projectsService', ['ngResource']);

    projectsService.factory('Projects', ['$resource', '$filter',
        function ($resource, $filter) {

            var item = $resource('api/projects/:profileId', { profileId: '@profileId' }, {
                query: { method: 'GET', params: {}, isArray: true }
            });
            item.prototype.endYear = function () {
                return $filter('date')(this.EndDate, 'yyyy');
            };
            return item;

        }]);

})();