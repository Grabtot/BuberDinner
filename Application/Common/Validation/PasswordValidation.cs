using FluentValidation;

namespace BuberDinner.Application.Common.Validation
{
    public static partial class PasswordValidation
    {
        public static IRuleBuilderOptions<T, string> HasUppercase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter");
        }

        public static IRuleBuilderOptions<T, string> HasLowercase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter");
        }

        public static IRuleBuilderOptions<T, string> HasDigit<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches("[0-9]")
                .WithMessage("Password must contain at least one digit");
        }

        public static IRuleBuilderOptions<T, string> HasSpecialCharacter<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches("[!*+_-]")
                .WithMessage("Password must contain at least one of the following special characters: * ! + _ -");
        }

        public static IRuleBuilderOptions<T, string> IsPassword<T>(this IRuleBuilder<T, string> ruleBuilder, int miniMumLength = 6)
        {
            return ruleBuilder
                .MinimumLength(miniMumLength)
                .HasUppercase()
                .HasLowercase()
                .HasDigit()
                .HasSpecialCharacter();
        }
    }
}
