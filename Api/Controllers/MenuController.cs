using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.AllHostMenus;
using BuberDinner.Application.Menus.Queries.Details;
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
        private readonly ISender _mediator;
        public MenuController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _mediator = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string hostId)
        {
            return Ok(await _mediator.Send(new AllHostMenusQuery(hostId)));
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> Get(string menuId)
        {
            MenuDetailsQuery query = new(menuId);

            ErrorOr<Menu> result = await _mediator.Send(query);

            return result.Match(menu => Ok(_mapper.Map<MenuResponse>(menu)), Problem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));

            ErrorOr<Menu> result = await _mediator.Send(command);

            return result.Match(menu => CreatedAtAction(nameof(Get), new { hostId, menuId = menu.Id.Value.ToString() }, null), Problem);
        }
    }
}
