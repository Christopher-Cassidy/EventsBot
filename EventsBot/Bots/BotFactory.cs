using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBot.Bots
{
    public class BotFactory
    {
        public static IBot Create(int id) {
            return new EventBot(id);
        }
    }
}
