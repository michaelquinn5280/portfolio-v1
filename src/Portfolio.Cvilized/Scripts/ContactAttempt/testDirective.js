(function() {
    'use strict';

    angular
        .module('portfolioApp')
        .directive('contactsendsubmit', contactSendSubmitDirective);

    function contactSendSubmitDirective() {
        var directive = {
            restrict: 'EA',
            templateUrl: 'html/test.html'
        };
        return directive;
    }

})();