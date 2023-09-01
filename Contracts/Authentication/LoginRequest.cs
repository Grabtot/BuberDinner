using MediatR;
using System.ComponentModel;

namespace BuberDinner.Contracts.Authentication
{
    public record LoginRequest : IRequest
    {
        [DefaultValue("dneshotkin@gmail.com")]
        public string Email { get; init; }

        [DefaultValue("Daniil13@13")]
        public string Password { get; init; }
    }
}
