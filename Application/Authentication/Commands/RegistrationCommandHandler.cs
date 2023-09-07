using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands
{
    public class RegistrationCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegistrationCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetByEmail(command.Email) != null)
            {
                return await Task.FromResult(Errors.User.DuplicateEmail);
            }

            User user = User.Create(
                 command.Email,
                 command.FirstName,
                 command.LastName,
                 command.Password);

            _userRepository.Add(user);

            string token = _jwtTokenGenerator.GenerateToken(user);

            return await Task.FromResult(new AuthenticationResult(user, token));
        }
    }
}
