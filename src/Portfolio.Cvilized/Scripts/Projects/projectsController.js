(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('projectsController', projectsController);

    projectsController.$inject = ['$scope', 'Projects'];

    function projectsController($scope, Projects) {
        $scope.projects = Projects.query();
        $scope.timelineBuckets = function () {
            var buckets = [];
            angular.forEach($scope.projects, function (project) {
                if (buckets.indexOf(project.endYear()) == -1) {
                    buckets.push(project.endYear());
                }
            });
            return buckets;
        };
    }
})();
