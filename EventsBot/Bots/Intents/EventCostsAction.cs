using EventsBot.Models;
using System.Linq;

namespace EventsBot.Bots
{
    public class EventCostsAction : EventAction {

        public EventCostsAction(CompanyEvent companyEvent) : base(companyEvent) { }
        
        protected override string GetText()
        {
            return $"The prices for the event are:\n\n{string.Join("\n\n", _companyEvent.Registration.Categories.Select(x => $"{x.Name}: ${x.Price}").ToArray())}";
        }

        protected override object GetData()
        {
            return _companyEvent.Registration;
        }
    }

    public class EventRegistrationAction : EventAction {
        private string _dateType;

        public EventRegistrationAction(CompanyEvent companyEvent, string dateType) : base(companyEvent) {
            _dateType = dateType ?? "";
        }

        protected override string GetText()
        {
            switch (_dateType.ToLower()) {
                case "":
                    return $"Registration for the event is from {_companyEvent.Registration} to {_companyEvent.Registration}.";

                case "start":
                    return $"Registration for the event opens {_companyEvent.Registration}.";

                case "end":
                    return $"Registration for the event closes {_companyEvent.Registration}.";

                default: break;
            }

            return "Not sure";
        }

        protected override object GetData()
        {
            return _companyEvent.Registration;
        }

    }
}