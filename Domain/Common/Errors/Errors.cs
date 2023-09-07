using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Account already exists");
        }

        public static class Dinner
        {
            public static Error MaxGuestsCount => Error.Conflict(
                code: "Dinner.MaxGuestsCount",
                description: "Dinner can not receive so many guests");
        }
    }
}
