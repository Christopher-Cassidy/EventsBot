using EventsBot.Models;

namespace EventsBot.Bots
{
    public class EventLocationAction : EventAction
    {
        protected readonly string _placeType;

        public EventLocationAction(CompanyEvent companyEvent) : base(companyEvent)
        {
        }

        protected override object GetData()
        {
            return _companyEvent.Location;
        }

        protected override string GetText() { 
            return $"The {_companyEvent.Name} event is being held at {_companyEvent.Location.DisplayName}.  Would you like to see a map?";
        }
    }
}