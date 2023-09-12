using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        private GuestId() { }

        public static GuestId Create(Guid id) => new(id);

        public static GuestId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
