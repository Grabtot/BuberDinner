using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries
{
    public record MenuDetailsQuery(
        string MenuId) : IRequest<ErrorOr<Menu>>;
}
