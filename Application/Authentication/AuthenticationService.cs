using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            User? user = _userRepository.GetByEmail(email);

            if (user is null || user.Password != password)
                return Errors.Authentication.WrongCredentials;

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetByEmail(email) != null)
            {
                return Errors.User.DuplicateEmail;
            }


            User user = new()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };

            _userRepository.Add(user);

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
