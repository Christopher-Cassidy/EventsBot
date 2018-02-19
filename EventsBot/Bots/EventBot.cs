using EventsBot.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventsBot.Bots
{
    public class EventBot : IBot
    {
        private readonly CompanyEvent companyEvent;

        public EventBot(int eventId) {
            //companyEvent = CompanyEventsDataContext.Events.Single(x => x.Id == eventId);
            companyEvent = CompanyEventsDataContext.Events[eventId];
        }

        public DialogFlowResponse GetResponse(DialogFlowRequest request) {

            var action = EventActionFactory.Create(request.result, companyEvent);

            return action.GetResponse();
        }
    }
}