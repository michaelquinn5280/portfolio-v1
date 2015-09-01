(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('contactInfoController', contactInfoController);

    contactInfoController.$inject = ['$scope', '$location', 'ProfileReference', 'ContactInfo'];

    function contactInfoController($scope, $location, ProfileReference, ContactInfo) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.contactInfo = ContactInfo.query({ profileId: profileReference.ProfileId });
        });
    }
})();
