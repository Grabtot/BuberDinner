using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.User;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            User? user = _userRepository.GetByEmail(query.Email);

            if (user is null || user.Password != query.Password)
                return await Task.FromResult(Errors.Authentication.WrongCredentials);

            string token = _jwtTokenGenerator.GenerateToken(user);

            return await Task.FromResult(new AuthenticationResult(user, token));
        }
    }
}