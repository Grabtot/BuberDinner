using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; private set; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique(Guid value)
            => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
