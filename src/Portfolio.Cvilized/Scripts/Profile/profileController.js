(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('profileController', profileController);

    profileController.$inject = ['$scope', '$location', 'Profile', 'ProfileReference'];

    function profileController($scope, $location, Profile, ProfileReference) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.profile = Profile.query({ profileId: profileReference.ProfileId });
        });
    }
})();
