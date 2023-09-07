using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenuController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        public MenuController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));

            ErrorOr<Menu> result = await _sender.Send(command);

            return result.Match(Ok, Problem);
        }
    }
}
