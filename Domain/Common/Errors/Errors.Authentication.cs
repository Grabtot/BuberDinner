using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error WrongCredentials => Error.Validation("Authentication.WrongCredentials", "Login failed");
        }
    }
}
