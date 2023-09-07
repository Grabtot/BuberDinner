using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public class RatingId : ValueObject
    {
        public Guid Value { get; private set; }

        private RatingId(Guid value)
        {
            Value = value;
        }

        public static RatingId CreateUnique()
            => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}