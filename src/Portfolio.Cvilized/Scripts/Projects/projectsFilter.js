(function () {

    'use strict';

    angular.module('portfolioApp')
        .filter('withProjectEndDate', function () {
            return function (projects, year) {
                var validProjects = [];

                angular.forEach(projects, function(project) {
                    if (project.endYear() == year) {
                        validProjects.push(project);
                    }
                });

                return validProjects;
            };
        })

})();