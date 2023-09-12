using BuberDinner.Application.Common.Validation;
using FluentValidation;

namespace BuberDinner.Application.Menus.Queries.AllHostMenus
{
    public class AllHostMenusQueryValidator : AbstractValidator<AllHostMenusQuery>
    {
        public AllHostMenusQueryValidator()
        {
            RuleFor(q => q.HostId).IsGuid();
        }
    }
}
