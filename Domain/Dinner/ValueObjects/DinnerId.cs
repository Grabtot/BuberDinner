using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }

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