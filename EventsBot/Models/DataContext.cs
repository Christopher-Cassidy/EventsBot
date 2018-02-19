using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;

namespace EventsBot.Models
{
    public class CompanyEventsDataContext
    {
        public static List<CompanyEvent> Events { get; private set; }

        private static Fixture _fixture = new Fixture();

        static CompanyEventsDataContext()
        {
            Events = _fixture.CreateMany<CompanyEvent>(5).ToList();
        }
    }
}
