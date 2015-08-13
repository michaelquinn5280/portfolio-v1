(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('greetingController', greetingController);

    greetingController.$inject = ['$scope', 'Greeting'];

    function greetingController($scope, Greeting) {
        $scope.greeting = Greeting.query();
    }
})();
