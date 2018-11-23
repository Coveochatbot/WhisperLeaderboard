using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models;
using Microsoft.AspNetCore.SignalR;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class AdminController : Controller
    {
        private static IHubContext<LeaderboardHub> _hubContext;
        private static ILeaderboard _leaderboard;
        private static IConfiguration _configuration;

        public AdminController(IHubContext<LeaderboardHub> hubContext, ILeaderboard leaderboard, IConfiguration configuration)
        {
            _hubContext = hubContext;
            _leaderboard = leaderboard;
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = Request.Cookies["Auth"];
            if (auth != _configuration["Auth"])
                filterContext.Result = RedirectToAction("GetLogin", "Login");

            base.OnActionExecuting(filterContext);
        }

        [HttpGet("")]
        public IActionResult GetAdmin()
        {
            this.ViewBag.Entries = _leaderboard;
            return View();
        }
    }
}
