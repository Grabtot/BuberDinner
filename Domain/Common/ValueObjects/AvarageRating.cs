using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; private set; }
        public int RatingsCount { get; private set; }

        private AverageRating(double value, int ratingsCount)
        {
            Value = value;
            RatingsCount = ratingsCount;
        }

        public void AddNewRating(Rating rating)
        {
            Value = ((Value * RatingsCount) + rating.Value) / ++RatingsCount;
        }

        internal void RemoveRating(Rating rating)
        {
            Value = ((Value * RatingsCount) - rating.Value) / --RatingsCount;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static AverageRating Create(double value = 0, int count = 0)
         => new(value, count);
    }
}
