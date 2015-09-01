(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('legalController', legalController);

    legalController.$inject = ['$scope', '$location', 'ProfileReference', 'Copyright'];

    function legalController($scope, $location, ProfileReference, Copyright) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.copyright = Copyright.query({ profileId: profileReference.ProfileId });
        });
    }
})();
