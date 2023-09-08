using BuberDinner.Application.Common.Validation;
using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.HostId).IsGuid();
        }
    }
}
