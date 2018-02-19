using EventsBot.Models;

namespace EventsBot.Bots
{
    public class EventLocationAction : EventAction
    {
        protected readonly string _placeType;

        public EventLocationAction(CompanyEvent companyEvent, string placeType) : base(companyEvent)
        {
            _placeType = placeType ?? "";
        }

        protected override string GetText() { 
            switch (_placeType.ToLower())
            {
                case "":
                    return $"The {_companyEvent.Name} event is being held at {_companyEvent.Location.Details}.  Would you like to see a map?";

                default:
                    if (_companyEvent.Facilities.ContainsKey(_placeType.ToLower()))
                    {
                        var place = _companyEvent.Facilities[_placeType.ToLower()];
                        return $"You can find the {place.Name} at {place.Directions}.";
                    }
                    break;
            }

            return "I don't know this place.";
        }
    }
}