(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('legalController', legalController);

    legalController.$inject = ['$scope', 'Copyright']; 

    function legalController($scope, Copyright) {
        $scope.copyright = Copyright.query();
    }
})();
