(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('experienceModalController', experienceModalController);

    experienceModalController.$inject = ['$scope', '$modal', '$sce'];

    function experienceModalController($scope, $modal, $sce) {
        $scope.items = [];
        $scope.title = '';
        $scope.companyUrl = '';
        $scope.animationsEnabled = true;

        $scope.open = function (size, items, title, link) {
            $scope.items = items;
            $scope.title = title;
            $scope.link = $sce.trustAsHtml(link);

            var modalInstance = $modal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'experienceModalContent.html',
                controller: 'modalInstanceController',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    },
                    title: function () {
                        return $scope.title;
                    },
                    link: function () {
                        return $scope.link;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };
    }
})();
