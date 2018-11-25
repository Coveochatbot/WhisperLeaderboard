"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/leaderboardHub").build();

connection.on("Update", function () {
    location.reload();
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});