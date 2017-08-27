//Angular chat service
angular.module('AngularChat')
    .service('Chat', ['$rootScope', function ChatService($rootScope) {
        var proxy = null;

        var initialize = function () {
            //Getting the connection object
            connection = $.hubConnection();

            //Creating proxy
            this.proxy = connection.createHubProxy('chat');

            //Starting connection
            connection.start();

            //Publishing an event when server pushes a new message
            this.proxy.on('receiveMessage', function (user, message, form) {
                console.log('pase1');
                $rootScope.$emit("receiveMessage", user, message, form);
            });
            console.log('initialize');
        };

        var sendMessage = function (user, message) {
            //Invoking the send method defined in hub ( note in ChatHub.cs it's Send javacript signalr changes it to send.)
            this.proxy.invoke('sendMessage', user, message, 'AngularJS Site');
        };

        //return service object.
        return {
            initialize: initialize,
            sendMessage: sendMessage
        };
    }]);