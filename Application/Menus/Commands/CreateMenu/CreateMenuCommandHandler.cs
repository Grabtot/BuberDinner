using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
        {
            Menu menu = Menu.Create(
                name: command.Name,
                description: command.Description,
                hostId: HostId.Create(command.HostId),
                sections: command.Sections.ConvertAll(menu => MenuSection.Create(
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
