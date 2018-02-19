using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsBot.Bots;
using EventsBot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsBot.Controllers
{
    [Produces("application/json")]
    [Route("api/events")]
    public class EventsController : Controller
    {
        // POST: api/events/{eventId}
        [HttpPost("{eventId}")]
        public DialogFlowResponse Post(int eventId, [FromBody]DialogFlowRequest request)
        {
            var bot = BotFactory.Create(eventId);
            return bot.GetResponse(request);
        }
    }
}
