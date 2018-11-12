using Microsoft.AspNetCore.SignalR;

namespace WhisperLeaderboard
{
    public class LeaderboardHub : Hub
    {
        public void Send()
        {
            Clients.All.SendAsync("Update");
        }
    }
}
