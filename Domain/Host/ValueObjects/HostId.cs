using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }

        private HostId(Guid value)
        {
            Value = value;
        }

        private HostId() { }

        public static HostId Create(string id) => Create(Guid.Parse(id));

        public static HostId Create(Guid id) => new(id);

        public static HostId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


    }
}