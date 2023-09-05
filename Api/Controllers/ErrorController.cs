using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]

        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features
                .Get<IExceptionHandlerFeature>()?.Error;

            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: exception?.Message);
        }
    }
}
