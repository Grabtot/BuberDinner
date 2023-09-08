using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries
{
    public class MenuDetailsQueryHandler : IRequestHandler<MenuDetailsQuery, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public MenuDetailsQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(MenuDetailsQuery request, CancellationToken cancellationToken)
        {
            MenuId id = MenuId.Create(request.MenuId);

            Menu? menu = _menuRepository.GetById(id);

            if (menu is null)
            {
                return Error.NotFound("Menu.NotFound", $"Menu with id {request.MenuId} not found");
            }

            return await Task.FromResult(menu);
        }
    }
}
