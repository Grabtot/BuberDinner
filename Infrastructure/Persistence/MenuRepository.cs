using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }

        public Menu? GetById(MenuId id)
        {
            return _menus.SingleOrDefault(menu => menu.Id == id);
        }
    }
}