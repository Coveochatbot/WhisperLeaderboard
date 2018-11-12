using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class AdminController : Controller
    {
        private static Leaderboard _leaderboard = new Leaderboard();

        public AdminController()
        {
        }

        [HttpGet("")]
        public IActionResult GetAdmin()
        {
            this.ViewBag.Entries = _leaderboard.Entries;
            return View(new EditDto());
        }

        [HttpPost("NewEntry")]
        public IActionResult AddNewEntry([FromBody] Entry entry)
        {
            return Ok("Entry added");
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] EditDto entry)
        {
            return RedirectToAction("GetAdmin");
            //return View(_leaderboard);
        }

        [HttpPost("Score")]
        public IActionResult VerifyScore([FromBody] ScoreDto score)
        {
            return Ok(_leaderboard.IsEligible(score.Score));
        }

        [HttpPost("NewLeaderboard")]
        public IActionResult InitializeNewLeadeboard([FromBody] LeaderboardDto leaderboardDto)
        {
            return Ok("Initialized leaderboard");
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] PositionDto position)
        {
            return Ok("Entry was removed");
        }
    }
}
