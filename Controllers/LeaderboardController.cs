﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhisperLeaderboard.ViewModels;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class LeaderboardController : Controller
    {
        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            return Ok("Leaderboard");
        }

        [HttpPost("NewEntry")]
        public IActionResult AddNewEntry()
        {
            return Ok("Entry added");
        }

        [HttpPost("Score")]
        public IActionResult VerifyScore()
        {
            return Ok("VerifyScore");
        }

        [HttpPost("NewLeaderboard")]
        public IActionResult InitializeNewLeadeboard()
        {
            return Ok("InitializeNewLeadeboard");
        }
    }
}