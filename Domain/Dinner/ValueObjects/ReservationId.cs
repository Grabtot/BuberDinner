using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; private set; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        private ReservationId() { }

        public static ReservationId CreateUnique()
            => new(Guid.NewGuid());

        public static ReservationId Create(Guid id) => new(id);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}