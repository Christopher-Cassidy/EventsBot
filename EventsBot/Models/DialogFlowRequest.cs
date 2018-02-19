using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBot.Models
{
    public class DialogFlowRequest
    {
        public List<string> contexts { get; set; }
        public string lang { get; set; }
        public string query { get; set; }
        public string sessionId { get; set; }
        public string timezone { get; set; }
        public DialogFlowResult result { get; set; }
    }

    public class DialogFlowResult
    {
        public string action { get; set; }
        public Dictionary<string, string> parameters { get; set; }
        public List<object> contexts { get; set; }
    }

    public class DialogFlowResponse {
        public string speech;           // Response to the request.
        public string displayText;      // Text displayed on the user device screen. 	
        public object data;             // Object  Additional data required for performing the action on the client side.The data is sent to the client in the original form and is not processed by Dialogflow.
        public List<object> contextOut; // Array of context objects Array of context objects set after intent completion.
        public string source;           // Data source.
        public object followupEvent;    // Object
    }
}
