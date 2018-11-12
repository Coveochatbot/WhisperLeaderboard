using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class AdminController : Controller
    {
        private static ILeaderboard _leaderboard;

        public AdminController(ILeaderboard leaderboard)
        {
            _leaderboard = leaderboard;
        }

        [HttpGet("")]
        public IActionResult GetAdmin()
        {

            this.ViewBag.Entries = _leaderboard.GetEntries();
            return View(new EditDto());
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] EditDto entry)
        {
            _leaderboard.RemoveEntry(entry.Position);
            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            return RedirectToAction("GetAdmin");
            //return View(_leaderboard);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromForm] EditDto entry)
        {
            _leaderboard.RemoveEntry(entry.Position);
            return RedirectToAction("GetAdmin");
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] EditDto entry)
        {
            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            return RedirectToAction("GetAdmin");
        }
    }
}
