"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/leaderboardHub").build();

connection.on("Update", function () {
    $("#mytable").load("Leaderboard #mytable");
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});