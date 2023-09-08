using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        private MenuSectionId() { }

        public static MenuSectionId Create(Guid id) => new(id);

        public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}