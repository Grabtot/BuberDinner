using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem>? items = null) : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items ?? new List<MenuItem>();
        }

        private MenuSection() { }

        public static MenuSection Create(string name, string description, List<MenuItem>? items = null)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items);
        }
    }
}