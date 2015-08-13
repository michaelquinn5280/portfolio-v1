(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('contactInfoController', contactInfoController);

    contactInfoController.$inject = ['$scope', 'ContactInfo'];

    function contactInfoController($scope, ContactInfo) {
        $scope.contactInfo = ContactInfo.query();
    }
})();
