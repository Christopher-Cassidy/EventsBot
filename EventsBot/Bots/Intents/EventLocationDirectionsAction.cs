using EventsBot.Models;
using System.Linq;

namespace EventsBot.Bots
{
    public class EventLocationDirectionsAction : EventAction
    {
        protected readonly TransportationType? _type;

        public EventLocationDirectionsAction(CompanyEvent companyEvent, string transportationMode) : base(companyEvent)
        {
            TransportationType type;
            if (TransportationType.TryParse(transportationMode, out type)) { _type = type; }
        }

        protected override string GetText()
        {
            if (_type.HasValue && _companyEvent.Location.Directions.Any(x => x.Type == _type.Value))
            {
                return $"Here are some directions: {_companyEvent.Location.Directions.Single(x => x.Type == _type.Value).Directions}";
            }
            else
            {
                return $"Here are some directions: {string.Join("\n", _companyEvent.Location.Directions.Select(x => x.Directions))}";
            }
        }
    }
}