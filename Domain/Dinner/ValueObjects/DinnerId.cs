using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private DinnerId(Guid value)
        {
            Value = value;
        }

        private DinnerId() { }

        public static DinnerId Create(Guid id) => new(id);

        public static DinnerId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}