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

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return _sender.Send(new AllHostMenusQuery)
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> Get(string menuId)
        {
            MenuDetailsQuery query = new(menuId);

            ErrorOr<Menu> result = await _sender.Send(query);

            return result.Match(menu => Ok(_mapper.Map<MenuResponse>(menu)), Problem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));

            ErrorOr<Menu> result = await _sender.Send(command);

            return result.Match(menu => CreatedAtAction(nameof(Get), new { hostId, menuId = menu.Id.Value.ToString() }, null), Problem);
        }
    }
}
