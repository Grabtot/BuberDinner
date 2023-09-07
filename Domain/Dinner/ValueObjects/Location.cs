using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private Location(string name,
                        string address,
                        double latitude,
                        double longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool IsWithinDistance(Location otherLocation, double radiusInKilometers)
        {
            double earthRadius = 6371;

            double latDiff = (otherLocation.Latitude - Latitude) * (Math.PI / 180.0);
            double lonDiff = (otherLocation.Longitude - Longitude) * (Math.PI / 180.0);

            double a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                       Math.Cos(Latitude * (Math.PI / 180.0)) * Math.Cos(otherLocation.Latitude * (Math.PI / 180.0)) *
                       Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadius * c;

            return distance <= radiusInKilometers;
        }

        public static Location Create(string name,
                                      string address,
                                      double latitude,
                                      double longitude)
        {
            return new(name, address, latitude, longitude);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Longitude;
            yield return Latitude;
        }
    }
}