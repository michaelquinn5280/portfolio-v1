(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('contactAttemptController', contactAttemptController);

    contactAttemptController.$inject = ['$scope', 'ContactAttempt'];

    function contactAttemptController($scope, ContactAttempt) {
        $scope.isSendContactSaving = false;
        $scope.sendContactAttempt = function () {
            $scope.isSendContactSaving = true;
            //$theForm = $(this);
            //$btn = $(this).find('#submit-button');
            //$btnText = $btn.text();
            //$(this).parent().append('<div class="alert"></div>');
            //$alert = $(this).parent().find('.alert');

            //$btn.find('.loading-icon').addClass('fa-spinner fa-spin ');
            //$btn.prop('disabled', true).find('span').text("Sending...");
            var newContactAttempt = {
                ProfileId: masterProfileId,
                Name: $scope.formContact.Name,
                EmailAddress: $scope.formContact.EmailAddress,
                Subject: $scope.formContact.Subject,
                Message: $scope.formContact.Message
            };

            ContactAttempt.send(newContactAttempt).$promise.then(
                function (data) {
                    if (data) {
                        $scope.isSendContactSaving = false;
                        //todo: pop toast for success
                    }
                    else {
                        $scope.isSendContactSaving = false;
                        //todo: pop toast for failure
                    }
                });
        }
    }
})();
