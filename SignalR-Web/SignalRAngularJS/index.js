"use strict";

$application.controller("index", ["$scope", "chat", function ($scope, chat) {
    $scope.messages = "Connected";

    $scope.click = function () {
        chat.server.send($scope.message); 
    };

    chat.client.addMessage = function (message) {

        console.log('pase');

        $scope.$apply(function () {
            console.log('pase');
            $scope.messages = $scope.messages + "\n" + message;
        });
    }; 
}]); 