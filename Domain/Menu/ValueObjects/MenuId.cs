using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        private MenuId() { }

        public static MenuId Create(string id) => Create(Guid.Parse(id));

        public static MenuId Create(Guid id) => new(id);

        public static MenuId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
