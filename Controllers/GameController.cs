using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models;
using WhisperLeaderboard.Models.Dto.Game;
using Quobject.SocketIoClientDotNet.Client;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class GameController : Controller
    {
        private IGameContext _gameContext;
        private static IConfiguration _configuration;
        private static ILeaderboard _leaderboard;

        public GameController(IConfiguration configuration, IGameContext context, ILeaderboard leaderboard)
        {
            _configuration = configuration;
            _gameContext = context;
            _leaderboard = leaderboard;
        }

        [HttpGet("")]
        [CookieRequired]
        public IActionResult Get()
        {
            return this.Ok();
        }

        [HttpGet("remaining")]
        [CookieRequired]
        public IActionResult GetTimeBeforeExplosion()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

            var time = Convert.ToInt32(_gameContext.GetBombRemainingTime(easternTime).TotalMilliseconds / 10);
            time = time < 0 ? 0 : time;

            var timeToDisplay =$"{ time / 6000}:{ ((time / 100) % 60).ToString("D2")}";
            return this.Ok(timeToDisplay);
        }

        [HttpPost("start")]
        [CookieRequired]
        public IActionResult StartGame([FromBody] StartParameters startParams)
        {
            _gameContext.NewGame(startParams);
            return this.Ok(startParams);
        }

        [HttpPost("name")]
        public IActionResult ReceiveName([FromBody] NameParameters nameParams)
        {
            _gameContext.NamePlayer(nameParams);
            return this.Ok(nameParams);
        }

        [HttpPost("strike")]
        [CookieRequired]
        public IActionResult Strike([FromBody] StrikeParameters strikeParams)
        {
            _gameContext.Strike(strikeParams);
            return this.Ok(strikeParams);
        }

        [HttpPost("end")]
        [CookieRequired]
        public IActionResult EndGame([FromBody] EndParameters endParams)
        {
            if (endParams.Success)
            {
                TimeSpan disarmTime = _gameContext.GetTimeSpend(endParams.EndTime);
                int score = Convert.ToInt32(disarmTime.TotalMilliseconds / 10);
                _leaderboard.InsertEntry(_gameContext.AgentName, _gameContext.DisarmerName, score, _gameContext.Mode);
            }

            var socket = IO.Socket(_configuration["ChatURL"]);
            socket.Emit("new");

            _gameContext.EndGame();
            return this.Ok(_gameContext.GetBombRemainingTime(endParams.EndTime));
        }

        private class CookieRequired : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                GameController gc = filterContext.Controller as GameController;

                var auth = filterContext.HttpContext.Request.Cookies["Auth"];
                if (auth != _configuration["Auth"])
                    filterContext.Result = gc.Unauthorized();

                base.OnActionExecuting(filterContext);
            }
        }
    }
}