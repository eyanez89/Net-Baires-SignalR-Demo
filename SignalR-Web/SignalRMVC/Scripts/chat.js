$(function () {
    var con = $.hubConnection();
    var hub = con.createHubProxy('chat');

    hub.on('receiveMessage', function (sender, msg) {
        var message = 'li class="left clearfix">';
        message += '<div class="chat-body clearfix">';
        message += '<div class="header">';
        message += '<strong class="primary-font">' + sender + '</strong> ';
        message += '</div>';
        message += '<p>' + msg + '</p>';
        message += '</div>';
        message += '</li>';

        $('#messages').append(message);
    });

    $('#btn-chat').click(function () {
        hub.invoke("SendMessage", "MVC Site", $('#btn-input').val());
        $('#btn-input').val("");
    });

    con.start().done(function () {
        $('#status').text('Connected');
    });
});