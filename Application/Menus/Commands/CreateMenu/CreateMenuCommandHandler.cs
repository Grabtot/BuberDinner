using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
        {
            Menu menu = Menu.Create(
                name: command.Name,
                description: command.Description,
                hostId: HostId.Create(command.HostId),
                sections: command.Sections?.ConvertAll(menu => MenuSection.Create(
                    name: menu.Name,
                    description: menu.Description,
                    items: menu.Items.ConvertAll(item => MenuItem.Create(
                        name: item.Name,
                        description: item.Description)))));

            _menuRepository.Add(menu);

            return await Task.FromResult(menu);
        }
    }
}
