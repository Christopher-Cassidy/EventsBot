using EventsBot.Models;

namespace EventsBot.Bots
{
    public class EventDatesAction : EventAction
    {
        protected readonly string _dateType;

        public EventDatesAction(CompanyEvent companyEvent, string dateType) : base(companyEvent) {
            _dateType = dateType ?? "";
        }
        
        protected override string GetText() { 
            switch (_dateType.ToLower())
            {
                case "start":
                    return $"The {_companyEvent.Name} event starts on {_companyEvent.StartDate.ToShortDateString()}.";

                case "end":
                    return $"The {_companyEvent.Name} event ends on {_companyEvent.EndDate.ToShortDateString()}.";

                default:
                    return $"The {_companyEvent.Name} event is from {_companyEvent.StartDate.ToShortDateString()} to {_companyEvent.EndDate.ToShortDateString()}.";
            }
        }
    }
}