﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class LeaderboardController : Controller
    {
        private static Leaderboard _leaderboard = new Leaderboard();
        private static IHubContext<LeaderboardHub> _hubContext;

        public LeaderboardController(IHubContext<LeaderboardHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            return View(_leaderboard);
        }

        [HttpPost("NewEntry")]
        public IActionResult AddNewEntry([FromBody] Entry entry)
        {
            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            _hubContext.Clients.All.SendAsync("Update");
            return Ok("Entry added");
        }

        [HttpPost("Score")]
        public IActionResult VerifyScore([FromBody] ScoreDto score)
        {
            return Ok(_leaderboard.IsEligible(score.Score));
        }

        [HttpPost("NewLeaderboard")]
        public IActionResult InitializeNewLeadeboard([FromBody] LeaderboardDto leaderboardDto)
        {
            _leaderboard = new Leaderboard(leaderboardDto.Entries, leaderboardDto.Size);
            return Ok("Initialized leaderboard");
        }
    }
}
