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
        private static IConfiguration _configuration;

        public GameController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = Request.Cookies["Auth"];
            if (auth != _configuration["Auth"])
                filterContext.Result = this.Unauthorized();

            base.OnActionExecuting(filterContext);
        }

        [HttpPost("start")]
        public IActionResult StartGame([FromBody] StartParameters startParams)
        {

            return this.Ok(startParams);
        }

        [HttpPost("name")]
        public IActionResult StartGame([FromBody] NameParameters nameParams)
        {

            return this.Ok(nameParams);
        }

        [HttpPost("strike")]
        public IActionResult Strike([FromBody] StrikeParameters strikeParams)
        {

            return this.Ok(strikeParams);
        }

        [HttpPost("end")]
        public IActionResult EndGame([FromBody] EndParameters endParams)
        {

            return this.Ok(endParams);
        }
    }
}