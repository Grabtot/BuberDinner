using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : RepositoryBase<Menu, MenuId>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}