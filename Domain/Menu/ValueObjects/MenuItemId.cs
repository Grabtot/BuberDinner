using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        private MenuItemId() { }

        public static MenuItemId Create(Guid id) => new(id);

        public static MenuItemId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuItemId Create(Guid id) => new(id);
    }
}