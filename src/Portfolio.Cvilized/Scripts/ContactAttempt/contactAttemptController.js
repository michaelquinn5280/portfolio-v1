(function () {
    'use strict';

    angular
        .module('portfolioApp')
        .controller('contactAttemptController', contactAttemptController);

    contactAttemptController.$inject = ['$scope', '$location', 'ProfileReference', 'ContactAttempt'];

    function contactAttemptController($scope, $location, ProfileReference, ContactAttempt) {
        $scope.isSendContactSaving = false;
        $scope.sendContactAttempt = function () {
            $scope.isSendContactSaving = true;
            ProfileReference.query({ reference: $location.host() }, function (profileReference) {
                var newContactAttempt = {
                    ProfileId: profileReference.ProfileId,
                    Name: $scope.formContact.Name,
                    EmailAddress: $scope.formContact.EmailAddress,
                    Subject: $scope.formContact.Subject,
                    Message: $scope.formContact.Message
                };

                ContactAttempt.send({ profileId: profileReference.ProfileId }, newContactAttempt).$promise.then(
                    function (data) {
                        if (data) {
                            $scope.isSendContactSaving = false;
                            $scope.formContact.Name = '';
                            $scope.formContact.EmailAddress = '';
                            $scope.formContact.Subject = '';
                            $scope.formContact.Message = '';
                            //todo: pop toast for success
                        }
                        else {
                            $scope.isSendContactSaving = false;
                            //todo: pop toast for failure
                        }
                    });
            });
        }
    }
})();
