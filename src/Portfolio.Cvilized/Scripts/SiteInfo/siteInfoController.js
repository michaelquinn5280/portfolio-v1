(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('siteInfoController', siteInfoController);

    siteInfoController.$inject = ['$scope', 'SiteInfo'];

    function siteInfoController($scope, SiteInfo) {
        $scope.siteInfo = SiteInfo.query();
    }
})();
