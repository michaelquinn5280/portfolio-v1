(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('aboutSiteModalController', aboutSiteModalController);

    aboutSiteModalController.$inject = ['$scope', '$modal', '$sce'];

    function aboutSiteModalController($scope, $modal, $sce) {
        $scope.items = ['Bootstrap with CVilized wrapper',
                        'AngularJs',
                        'ASP.NET 5 Preview Templates',
                        $sce.trustAsHtml('<a class="modal-link" href="http://cvservices.azurewebsites.net/help" target="_blank">Web API</a> with .NET 4.6'),
                        'Application Insights Telemetry',
                        'MongoLab Data',
                        'Hosted in Azure',
                        $sce.trustAsHtml('Source available on <a class="modal-link" href="https://github.com/michaelquinn5280/Portfolio" target="_blank">GitHub</a>')];
        $scope.title = 'SITE SUMMARY';
        $scope.link = '';
        $scope.animationsEnabled = true;

        $scope.open = function (size) {
            var modalInstance = $modal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'aboutSiteModalContent.html',
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
