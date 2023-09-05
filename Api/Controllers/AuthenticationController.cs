using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _sender;

        public AuthenticationController(ISender sender)
        {
            _sender = sender;
        }


        /// <summary>
        /// Login the user
        /// </summary>
        /// <remarks>
        /// POST auth/login
        /// </remarks>
        /// <param name="request">Model with login info</param>
        /// <respoce code="500">Error</respoce>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> result = await _sender.Send(new LoginQuery(
                request.Email,
                request.Password));

            return result.Match(result => Ok(MapResult(result)), Problem);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> result = await _sender.Send(new RegisterCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password));

            return result.Match(authResult => Ok(MapResult(authResult)), Problem);
        }

        private static AuthenticationResponse MapResult(AuthenticationResult result)
        {
            return new()
            {
                Id = result.User.Id,
                Email = result.User.Email,
                FirstName = result.User.FirstName,
                LastName = result.User.LastName,
                Token = result.Token,
            };
        }
    }
}

