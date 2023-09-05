using System.ComponentModel;

namespace BuberDinner.Contracts.Authentication
{
    public record LoginRequest
    {
        [DefaultValue("dneshotkin@gmail.com")]
        public string Email { get; init; }

        [DefaultValue("Daniil13@13")]
        public string Password { get; init; }
    }
}
