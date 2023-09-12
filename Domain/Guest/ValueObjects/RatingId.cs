using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public class RatingId : ValueObject
    {
        public Guid Value { get; private set; }

        private RatingId(Guid value)
        {
            Value = value;
        }

        private RatingId() { }

        public static RatingId Create(Guid id) => new(id);
        public static RatingId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}