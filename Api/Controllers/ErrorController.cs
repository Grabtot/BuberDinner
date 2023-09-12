using BuberDinner.Application.Common.Errors;
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

            (int statusCode, string message) = exception switch
            {
                IServiceException serviceException => (serviceException.StatusCode, serviceException.Message),
                InvalidOperationException => (StatusCodes.Status500InternalServerError, exception.Message),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
            };

            return Problem(
                statusCode: statusCode,
                title: message);
        }
    }
}
