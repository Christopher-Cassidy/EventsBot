using EventsBot.Models;

namespace EventsBot.Bots
{
    public interface IBotAction
    {
        DialogFlowResponse GetResponse();
    }
}