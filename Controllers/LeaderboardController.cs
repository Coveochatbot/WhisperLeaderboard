using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class LeaderboardController : Controller
    {
        private static ILeaderboard _leaderboard;
        private static IHubContext<LeaderboardHub> _hubContext;
        private static IConfiguration _configuration;

        private bool _isAdmin = false;

        public LeaderboardController(IHubContext<LeaderboardHub> hubContext, ILeaderboard leaderboard, IConfiguration configuration)
        {
            _hubContext = hubContext;
            _leaderboard = leaderboard;
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = Request.Cookies["Auth"];
            if (auth == _configuration["Auth"])
                _isAdmin = true;

            base.OnActionExecuting(filterContext);
        }

        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            return View(_leaderboard);
        }

        [HttpPost("NewEntry")]
        public IActionResult NewEntry([FromForm] EditDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_isAdmin)
            {
                return Unauthorized();
            }

            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            _hubContext.Clients.All.SendAsync("Update");
            return Redirect(Request.Headers["Referer"]);
        }

        [HttpPost("Score")]
        public IActionResult VerifyScore([FromBody] ScoreDto score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_leaderboard.IsEligible(score.Score));
        }

        [HttpPost("NewLeaderboard")]
        public IActionResult InitializeNewLeadeboard([FromBody] LeaderboardDto leaderboardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_isAdmin)
            {
                return Unauthorized();
            }
            _leaderboard = new Leaderboard(leaderboardDto.Entries, leaderboardDto.Size);
            _hubContext.Clients.All.SendAsync("Update");
            return Redirect(Request.Headers["Referer"]);
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromForm] EditDto entry)
        {
            if (!_isAdmin)
            {
                return Unauthorized();
            }

            _leaderboard.RemoveEntry(entry.Position);
            _hubContext.Clients.All.SendAsync("Update");
            return Redirect(Request.Headers["Referer"]);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] EditDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_isAdmin)
            {
                return Unauthorized();
            }

            _leaderboard.RemoveEntry(entry.Position);
            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            _hubContext.Clients.All.SendAsync("Update");

            return Redirect(Request.Headers["Referer"]);
        }

        [HttpPost("Resize")]
        public IActionResult Resize([FromForm] PositionDto maxPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_isAdmin)
            {
                return Unauthorized();
            }

            _leaderboard.Resize(maxPosition.Position);
            _hubContext.Clients.All.SendAsync("Update");
            return Redirect(Request.Headers["Referer"]);
        }
    }
}
