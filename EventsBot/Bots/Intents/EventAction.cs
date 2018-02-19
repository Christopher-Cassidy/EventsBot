using EventsBot.Models;

namespace EventsBot.Bots
{
    public abstract class EventAction : IBotAction
    {
        protected readonly CompanyEvent _companyEvent;
        
        public EventAction(CompanyEvent companyEvent)
        {
            _companyEvent = companyEvent;
        }

        public virtual DialogFlowResponse GetResponse() {
            var txt = GetText();
            var data = GetData();

            return new DialogFlowResponse()
            {
                speech = txt,
                displayText = txt,
                data = data,
            };
        }

        protected abstract string GetText();

        protected virtual object GetData() {
            return _companyEvent;
        }
    }
}