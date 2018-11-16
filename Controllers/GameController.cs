using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using WhisperLeaderboard.Models.Dto.Game;

namespace WhisperLeaderboard.Controllers
{
    [Route("/[Controller]")]
    public class GameController : Controller
    {
        private IGameContext _gameContext;
        private static IConfiguration _configuration;

        public GameController(IConfiguration configuration, IGameContext context)
        {
            _configuration = configuration;
            _gameContext = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = Request.Cookies["Auth"];
            if (auth != _configuration["Auth"])
                filterContext.Result = this.Unauthorized();

            base.OnActionExecuting(filterContext);
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return this.Ok();
        }

        [HttpGet("remaining")]
        public IActionResult GetTimeBeforeExplosion()
        {
            return this.Ok(_gameContext.RemainingTime);
        }

        [HttpPost("start")]
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
        public IActionResult Strike([FromBody] StrikeParameters strikeParams)
        {
            _gameContext.Strike(strikeParams);
            return this.Ok(strikeParams);
        }

        [HttpPost("end")]
        public IActionResult EndGame([FromBody] EndParameters endParams)
        {
            // TODO before calling end game:
            // Send the score in endParams to the leaderboard if success is true. We must send the name of the disarmer, the name of the agent and the time it took to disarm the bomb
            // Then, we must send to the web socket server a reset signal for the UI to prompt for new names.
            _gameContext.EndGame();
            return this.Ok(_gameContext.RemainingTime);
        }
    }
}