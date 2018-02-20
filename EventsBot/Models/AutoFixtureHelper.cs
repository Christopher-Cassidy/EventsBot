using AutoFixture;
using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EventsBot.Models
{
    public static class AutoFixtureHelper
    {
        public static Fixture CreateCustomFixture()
        {
            var fixture = new Fixture();

            fixture.Customizations.Add(new AutoIncrementIdSpecimenBuilder());
            fixture.Customizations.Add(new SortOrderSpecimenBuilder());
            fixture.Customizations.Add(new SequentialDatesSpecimenBuilder());
            fixture.Customizations.Add(new NamesSpecimenBuilder());
            fixture.Customizations.Add(new DescriptionSpecimenBuilder());
            fixture.Customizations.Add(new LatLngSpecimenBuilder());
            fixture.Customizations.Add(new UrlSpecimenBuilder());

            return fixture;
        }
    }

    public class AutoIncrementIdSpecimenBuilder : ISpecimenBuilder
    {
        readonly Dictionary<string, int> _identity = new Dictionary<string, int>();

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo != null &&
                propertyInfo.Name.EndsWith("Id") &&
                propertyInfo.PropertyType == typeof(int))
            {
                var key = $"{propertyInfo.DeclaringType?.FullName}.{propertyInfo.Name}";

                if (!_identity.ContainsKey(key)) _identity.Add(key, 1);

                return _identity[key]++;
            }

            return new NoSpecimen();
        }
    }

    public class SortOrderSpecimenBuilder : ISpecimenBuilder
    {
        readonly Dictionary<string, int> _sortOrder = new Dictionary<string, int>();

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(int) &&
                (propertyInfo.Name.Equals("SortOrder") ||
                    propertyInfo.Name.Equals("Order")))
            {
                if (!_sortOrder.ContainsKey(propertyInfo.DeclaringType.FullName))
                {
                    _sortOrder.Add(propertyInfo.DeclaringType.FullName, 1);
                }
                return _sortOrder[propertyInfo.DeclaringType?.FullName]++;
            }

            return new NoSpecimen();
        }
    }

    public class SequentialDatesSpecimenBuilder : ISpecimenBuilder
    {
        readonly Dictionary<string, DateTime> _dates = new Dictionary<string, DateTime>();

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(DateTime) &&
                (propertyInfo.Name.Contains("Date")))
            {
                if (!_dates.ContainsKey(propertyInfo.DeclaringType.FullName))
                {
                    _dates.Add(propertyInfo.DeclaringType.FullName, DateTime.Today);
                }
                else
                {
                    _dates[propertyInfo.DeclaringType?.FullName] = _dates[propertyInfo.DeclaringType?.FullName].AddDays(1);
                }

                return _dates[propertyInfo.DeclaringType?.FullName];
            }

            return new NoSpecimen();
        }
    }

    public class NamesSpecimenBuilder : ISpecimenBuilder
    {
        private int index = 0;
        private List<string> bucket = new List<string>() { "Wombat", "Kangaroo", "Cockatoo", "Rosella", "Goanna", "Penguin", "Eagle" };

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(string) &&
                (propertyInfo.Name.Contains("Name") || propertyInfo.Name.Contains("Name")))
            {
                return bucket[index++ % (bucket.Count - 1)];
            }

            return new NoSpecimen();
        }
    }

    public class DescriptionSpecimenBuilder : ISpecimenBuilder
    {
        private string loermIpsum = "Lorem ipsum delorem explorem ignorem totalboredom";

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(string) &&
                (propertyInfo.Name.Contains("Description") || propertyInfo.Name.Contains("Details")))
            {
                return loermIpsum;
            }

            return new NoSpecimen();
        }
    }

    public class LatLngSpecimenBuilder : ISpecimenBuilder
    {
        private Random rnd = new Random();
        
        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(double) &&
                (propertyInfo.Name.ToLower().Equals("lat") || propertyInfo.Name.ToLower().Equals("lng")))
            {
                return rnd.NextDouble() * 180 - 90;
            }

            return new NoSpecimen();
        }
    }

    public class UrlSpecimenBuilder : ISpecimenBuilder
    {
        private string rootUrl = "http://www.example.org";

        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null &&
                propertyInfo.PropertyType == typeof(Uri))
            {
                return new Uri($"{rootUrl}/{Guid.NewGuid()}");
            }

            return new NoSpecimen();
        }
    }
}
