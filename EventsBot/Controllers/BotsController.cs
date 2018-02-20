using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsBot.Bots;
using EventsBot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsBot.Controllers
{
    [Produces("application/json")]
    [Route("api/bots")]
    [Authorize()] // Require authenticated requests.
    public class BotsController : Controller
    {
        // POST: api/bots/{botName}/{botId}
        [HttpPost("{botName}/{botId}")]
        public DialogFlowResponse Post(string botName, int botId, [FromBody]DialogFlowRequest request)
        {
            var bot = BotFactory.Create(botName, botId);
            return bot.GetResponse(request);
        }
    }
}
