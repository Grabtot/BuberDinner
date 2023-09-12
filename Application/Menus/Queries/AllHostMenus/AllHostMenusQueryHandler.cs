using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.AllHostMenus
{
    public class AllHostMenusQueryHandler : IRequestHandler<AllHostMenusQuery, IEnumerable<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public AllHostMenusQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> Handle(AllHostMenusQuery request, CancellationToken cancellationToken)
        {
            HostId hostId = HostId.Create(request.HostId);

            IEnumerable<Menu> menus = _menuRepository.GetByHostId(hostId);

            return await Task.FromResult(menus);
        }
    }
}
