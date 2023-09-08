using BuberDinner.Application.Common.Validation;
using FluentValidation;

namespace BuberDinner.Application.Menus.Queries
{
    public class MenuDetailsQueryValidator : AbstractValidator<MenuDetailsQuery>
    {
        public MenuDetailsQueryValidator()
        {
            RuleFor(q => q.MenuId).IsGuid();
        }
    }
}
