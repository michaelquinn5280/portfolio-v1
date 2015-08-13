(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('profileController', profileController);

    profileController.$inject = ['$scope', 'Profile']; 

    function profileController($scope, Profile) {
        $scope.profile = Profile.query();
    }
})();
