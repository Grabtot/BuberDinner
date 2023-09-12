using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BillId(Guid value)
        {
            Value = value;
        }

        private BillId() { }

        public static BillId CreateUnique()
            => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}