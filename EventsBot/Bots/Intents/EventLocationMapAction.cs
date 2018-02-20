using EventsBot.Models;

namespace EventsBot.Bots
{
    public class EventLocationMapAction : EventAction
    {
        protected readonly string _placeType;

        public EventLocationMapAction(CompanyEvent companyEvent) : base(companyEvent)
        {
        }

        protected override string GetText()
        {
            return $"Here is a map of the location: {_companyEvent.Location.MapUrl}.  Do you need directions?";
        }
    }
}