using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> result = _authenticationService.Login(
                request.Email,
                request.Password);

            return result.Match(result => Ok(MapResult(result)), Problem);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> result = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

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

