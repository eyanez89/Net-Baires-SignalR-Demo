$(function () {
    var user = "MVC Site";

    $('#btn-user').click(function () {
        user = $('#username').val();
        $('#username').val('');

        $('.row').toggle();
    });

    var con = $.hubConnection();
    var hub = con.createHubProxy('chat');

    hub.on('receiveMessage', function (sender, msg, from) {
        var message = '<li class="left clearfix">';
        message += '<div class="chat-body clearfix">';
        message += '<div class="header">';
        message += '<strong class="primary-font">' + sender + '</strong> ';
        message += '<p> Send From' + from + '</p>';
        message += '</div>';
        message += '<p>' + msg + '</p>';
        message += '</div>';
        message += '</li>';

        $('#messages').append(message);
    });

    $('#btn-chat').click(function () {
        hub.invoke("SendMessage", user, $('#btn-input').val(), "MVC Site");
        $('#btn-input').val("");
    });

    con.start().done(function () {
        $('#status').text('Connected');
    });
});