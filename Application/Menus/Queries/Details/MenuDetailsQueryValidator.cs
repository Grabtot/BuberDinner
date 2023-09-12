using BuberDinner.Application.Common.Validation;
using FluentValidation;

namespace BuberDinner.Application.Menus.Queries.Details
{
    public class MenuDetailsQueryValidator : AbstractValidator<MenuDetailsQuery>
    {
        public MenuDetailsQueryValidator()
        {
            RuleFor(q => q.MenuId).IsGuid();
        }
    }
}
