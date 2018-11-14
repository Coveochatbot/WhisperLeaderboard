using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto;
using Microsoft.AspNetCore.SignalR;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class LoginController : Controller
    {
        private static IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("")]
        public IActionResult GetLogin()
        {
            var auth = Request.Cookies["Auth"];
            if (auth == _configuration["Auth"])
                return RedirectToAction("GetAdmin", "Admin");

            return View();
        }

        [HttpPost("")]
        public IActionResult Login([FromForm] PasswordDto pwd)
        {
            if (pwd.Password != _configuration["Pass"])
                return Unauthorized();

            this.ControllerContext.HttpContext.Response.Cookies.Append("Auth", _configuration["Auth"]);
            return RedirectToAction("GetAdmin", "Admin");
        }
    }
}
