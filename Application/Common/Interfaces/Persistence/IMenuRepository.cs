using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
        Menu? GetById(MenuId id);
    }
}
