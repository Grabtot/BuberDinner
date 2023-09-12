using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : RepositoryBase<Menu, MenuId>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Menu> GetByHstId(HostId hostId)
        {
            return Context.Menus.Where(menu => menu.HostId == hostId);
        }
    }
}