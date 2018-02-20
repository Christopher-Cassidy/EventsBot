using EventsBot.Models;
using System.Linq;

namespace EventsBot.Bots
{
    public class EventCostsAction : EventAction {

        public EventCostsAction(CompanyEvent companyEvent) : base(companyEvent) { }
        
        protected override string GetText()
        {
            return $"The prices for the event are:\n\n{string.Join("\n\n", _companyEvent.Registration.Categories.Select(x => $"{x.Name}: {x.Price:C2}").ToArray())}";
        }

        protected override object GetData()
        {
            return _companyEvent.Registration;
        }
    }
}