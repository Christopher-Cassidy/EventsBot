using EventsBot.Models;

namespace EventsBot.Bots
{
    public class EventRegistrationAction : EventAction {
        private string _dateType;

        public EventRegistrationAction(CompanyEvent companyEvent, string dateType) : base(companyEvent) {
            _dateType = dateType ?? "";
        }

        protected override string GetText()
        {
            switch (_dateType.ToLower()) {
                case "":
                    return $"Registration for the event is from {_companyEvent.Registration.StartDate.ToString("dd.MM.yyyy, HH:mm")} to {_companyEvent.Registration.EndDate.ToString("dd.MM.yyyy, HH:mm")}.";

                case "start":
                    return $"Registration for the event opens {_companyEvent.Registration.StartDate.ToString("dd.MM.yyyy, HH:mm")}.";

                case "end":
                    return $"Registration for the event closes {_companyEvent.Registration.EndDate.ToString("dd.MM.yyyy, HH:mm")}.";

                default: break;
            }

            return "Please check the website for registration dates";
        }

        protected override string GetSpeech()
        {
            switch (_dateType.ToLower())
            {
                case "":
                    return $"Registration for the event is from {_companyEvent.Registration.StartDate.ToString("dddd, dd MMMM yyyy, HH:mm")} to {_companyEvent.Registration.EndDate.ToString("dddd, dd MMMM yyyy, HH:mm")}.";

                case "start":
                    return $"Registration for the event opens {_companyEvent.Registration.StartDate.ToString("dddd, dd MMMM yyyy, HH:mm")}.";

                case "end":
                    return $"Registration for the event closes {_companyEvent.Registration.EndDate.ToString("dddd, dd MMMM yyyy, HH:mm")}.";

                default: break;
            }

            return "Please check the website for registration dates";
        }

        protected override object GetData()
        {
            return _companyEvent.Registration;
        }

    }
}