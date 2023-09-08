using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        private MenuItem() { }

        public static MenuItem Create(string name, string description)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                description);
        }
    }
}