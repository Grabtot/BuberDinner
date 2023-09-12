using BuberDinner.Domain.Menu;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.AllHostMenus
{
    public record AllHostMenusQuery(string HostId)
        : IRequest<IEnumerable<Menu>>;
}
