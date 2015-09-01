(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('siteInfoController', siteInfoController);

    siteInfoController.$inject = ['$scope', '$location', 'ProfileReference', 'SiteInfo'];

    function siteInfoController($scope, $location, ProfileReference, SiteInfo) {
        ProfileReference.query({ reference: $location.host() }, function (profileReference) {
            $scope.siteInfo = SiteInfo.query({ profileId: profileReference.ProfileId });
        });
    }
})();
