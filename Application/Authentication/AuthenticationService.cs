using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "first name",
                "last name",
                email,
                "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid userId = Guid.NewGuid();

            string token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                    userId,
                    firstName,
                    lastName,
                    email,
                    token);
        }
    }
}
