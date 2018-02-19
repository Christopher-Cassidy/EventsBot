using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBot.Models
{
    public class CompanyEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location Location { get; set; }
        public Dictionary<string, Location> Facilities { get; set; }
        public EventSchedule Schedule { get; set; }
        public EventRegistration Registration { get; set; }
    }

    public class EventSchedule {
        public Uri Url { get; set; }
        public List<EventSession> Sessions { get; set; }
    }

    public class EventRegistration
    {
        public Uri Url { get; set; }
        public List<EventRegistrationCategory> Categories { get; set; }
    }

    public class EventRegistrationCategory {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
    
    public class EventSession {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Leader { get; set; }
        public Location Location { get; set; }
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Uri Url { get; set; }
        public int Capacity { get; set; }
        public int RemainingCapacity { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public List<Transportation> Directions { get; set; }
        public Uri MapUrl { get; set; }   
        public GeoPoint LatLng { get; set; }
    }

    public enum TransportationType {
        Walking,
        Cycling,
        Boat,
        Car,
        Train,
        Subway,
        Tram,
        Bus
    }

    public class Transportation {
        public TransportationType Type { get; set; }
        public string DisplayName { get; set; }
        public string Directions { get; set; }
        public string Description { get; set; }
        public Uri MapUrl { get; set; }
    }

    public class GeoPoint
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
