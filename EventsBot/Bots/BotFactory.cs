using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBot.Bots
{
    public class BotFactory
    {
        public static IBot Create(string botName, int botId) {
            switch (botName.ToLower()) {
                case "events":
                    return new EventBot(botId);
                default: throw new Exception("Bot not found");
            }
        }
    }
}
