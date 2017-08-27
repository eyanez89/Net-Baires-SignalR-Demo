"use strict";

(function (global) {
    function registerHubFactory($provide, hubName) {
        $provide.factory(hubName, function () {
            var proxy = $.connection.hub.createHubProxy(hubName);

            return proxy;
        });
    }

    function __nothing() { }

    function setupAndRegisterProxies($provide) {
        for (var property in $.connection) {
            var value = $.connection[property];

            if (typeof value !== "undefined" && value !== null) {
                if (typeof value.hubName !== "undefined" && value !== null) {
                    var hubName = property;

                    var proxy = $.connection.hub.createHubProxy(hubName);
                    proxy.client.__need_this_for_subscription__ = __nothing;

                    registerHubFactory($provide, hubName);
                }
            }
        }
    }

    var application = angular.module("SignalRChat", []);

    application.config(["$provide", function ($provide) {
        setupAndRegisterProxies($provide);

        $.connection.hub.start().done(function () {
            console.log("Hub connection up and running");
        });
    }]);

    global.$application = application;
})(window);