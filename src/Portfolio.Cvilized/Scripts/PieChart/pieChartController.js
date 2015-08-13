(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('pieChartController', pieChartController);

    pieChartController.$inject = ['$scope'];

    function pieChartController($scope) {
        $scope.options = {
            animate: {
                duration: 2000,
                enabled: true
            },
            barColor: '#CF5037',
            trackColor:'#545454',
            size: 180,
            scaleColor: false
        };
    }
})();
