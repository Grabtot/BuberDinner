using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
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
            LoginQuery query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> result = await _sender.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                Problem);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> result = await _sender.Send(command);

            return result.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                Problem);
        }
    }
}

