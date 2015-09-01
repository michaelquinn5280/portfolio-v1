(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('projectsController', projectsController);

    projectsController.$inject = ['$scope', '$location', 'ProfileReference', 'Projects'];

    function projectsController($scope, $location, ProfileReference, Projects) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.projects = Projects.query({ profileId: profileReference.ProfileId });
            $scope.timelineBuckets = function () {
                var buckets = [];
                angular.forEach($scope.projects, function (project) {
                    if (buckets.indexOf(project.endYear()) == -1) {
                        buckets.push(project.endYear());
                    }
                });
                return buckets;
            };
        });
    }
})();
