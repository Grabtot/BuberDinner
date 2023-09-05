using System.ComponentModel;

namespace BuberDinner.Contracts.Authentication
{
    public record RegisterRequest
    {
        [DefaultValue("Daniil")]
        public string FirstName { get; init; }

        [DefaultValue("Neshchotkin")]
        public string LastName { get; init; }

        [DefaultValue("dneshotkin@gmail.com")]
        public string Email { get; init; }

        [DefaultValue("Daniil13@13")]
        public string Password { get; init; }
    }
}