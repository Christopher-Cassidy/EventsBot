using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsBot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsBot.Controllers
{
    [Produces("application/json")]
    [Route("api/CompanyEvents")]
    public class CompanyEventsController : Controller
    {
        // GET: api/Events
        [HttpGet]
        public IEnumerable<CompanyEvent> Get()
        {
            return CompanyEventsDataContext.Events.ToList();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public CompanyEvent Get(int id)
        {
            //return CompanyEventsDataContext.Events.Single(x => x.Id == id);
            return CompanyEventsDataContext.Events[id];
        }

        // POST: api/Events
        [HttpPost]
        public void Post([FromBody]CompanyEvent value)
        {
            value.Id = Math.Max(1, CompanyEventsDataContext.Events.Max(x => x.Id));
            CompanyEventsDataContext.Events.Add(value);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CompanyEvent value)
        {
            //var old = CompanyEventsDataContext.Events.Single(x => x.Id == id);
            var old = CompanyEventsDataContext.Events[id];
            if (old != null)
            {
                CompanyEventsDataContext.Events.Remove(CompanyEventsDataContext.Events.Single(x => x.Id == id));
                CompanyEventsDataContext.Events.Add(value);
            }
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var old = CompanyEventsDataContext.Events.Single(x => x.Id == id);
            var old = CompanyEventsDataContext.Events[id];
            CompanyEventsDataContext.Events.Remove(old);
        }
    }
}
