(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('greetingController', greetingController);

    greetingController.$inject = ['$scope', '$location', 'ProfileReference', 'Greeting'];

    function greetingController($scope, $location, ProfileReference, Greeting) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.greeting = Greeting.query({ profileId: profileReference.ProfileId });
        });
    }
})();
