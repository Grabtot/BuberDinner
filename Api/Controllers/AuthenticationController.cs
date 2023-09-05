﻿using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            AuthenticationResult result = _authenticationService.Login(
                request.Email,
                request.Password);

            AuthenticationResponse response = new()
            {
                Id = result.User.Id,
                Email = result.User.Email,
                FirstName = result.User.FirstName,
                LastName = result.User.LastName,
                Token = result.Token,
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            AuthenticationResult result = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            AuthenticationResponse response = new()
            {
                Id = result.User.Id,
                Email = result.User.Email,
                FirstName = result.User.FirstName,
                LastName = result.User.LastName,
                Token = result.Token,
            };

            return Ok(response);
        }
    }
}

