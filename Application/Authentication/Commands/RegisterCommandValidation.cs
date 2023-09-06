
using BuberDinner.Application.Common.Validation;
using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands
{
    public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation()
        {
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.FirstName).Length(2, 32);
            RuleFor(c => c.LastName).Length(2, 32);
            RuleFor(c => c.Password).NotEmpty().IsPassword(8);
        }

    }
}
