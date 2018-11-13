using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class AdminController : Controller
    {
        private static ILeaderboard _leaderboard;
        private static IConfiguration _configuration;

        public AdminController(ILeaderboard leaderboard, IConfiguration configuration)
        {
            _leaderboard = leaderboard;
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = Request.Cookies["Auth"];
            if (filterContext.ActionDescriptor.RouteValues["action"] != "Login" && auth != _configuration["Auth"])
                filterContext.Result = View("GetLogin", new PasswordDto());

            base.OnActionExecuting(filterContext);
        }

        [HttpGet("")]
        public IActionResult GetAdmin()
        {
            this.ViewBag.Entries = _leaderboard.GetEntries();
            return View(new EditDto());
        }

        [HttpGet("Login")]
        public IActionResult GetLogin()
        {
            var auth = Request.Cookies["Auth"];
            if (auth == _configuration["Auth"])
                return RedirectToAction("GetAdmin");

            return View("GetLogin", new PasswordDto());
        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm] PasswordDto pwd)
        {
            if (pwd.Password != _configuration["Pass"])
                return Unauthorized();

            this.ControllerContext.HttpContext.Response.Cookies.Append("Auth", _configuration["Auth"]);
            return RedirectToAction("GetAdmin");
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] EditDto entry)
        {
            _leaderboard.RemoveEntry(entry.Position);
            _leaderboard.InsertEntry(entry.Name1, entry.Name2, entry.Score);
            return RedirectToAction("GetAdmin");
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

        [HttpPost("Resize")]
        public IActionResult Resize([FromForm] EditDto entry)
        {
            _leaderboard.Resize(entry.Position);
            return RedirectToAction("GetAdmin");
        }
    }
}
