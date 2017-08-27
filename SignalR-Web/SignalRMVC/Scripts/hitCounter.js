$(function () {
    // create a signalr connection
    var con = $.hubConnection();

    // create a hub proxy
    var hub = con.createHubProxy('hitCounterHub');

    // an event handler for a hub-generated event
    hub.on('receiveHit', function (count) {
        $('#counter').text(count);
    });

    // start the connection
    con.start(function () {

        // [we're connected now, so] record the site's hit
        hub.invoke('RecordHit');
    });
});