using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(q => q.Email).EmailAddress();
            RuleFor(q => q.Password).NotEmpty();
        }
    }
}
