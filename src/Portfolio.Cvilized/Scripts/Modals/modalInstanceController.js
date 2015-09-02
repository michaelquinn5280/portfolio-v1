(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('modalInstanceController', modalInstanceController);

    modalInstanceController.$inject = ['$scope', '$modalInstance', 'items', 'title', 'link'];

    function modalInstanceController($scope, $modalInstance, items, title, link) {
        $scope.items = items;
        $scope.title = title;
        $scope.link = link;
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function () {
            $modalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();
