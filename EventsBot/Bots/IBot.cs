namespace EventsBot.Bots
{
    public interface IBot {
        Models.DialogFlowResponse GetResponse(Models.DialogFlowRequest request);
    }
}
