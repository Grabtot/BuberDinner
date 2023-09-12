using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.Details
{
    public record MenuDetailsQuery(
        string MenuId) : IRequest<ErrorOr<Menu>>;
}
