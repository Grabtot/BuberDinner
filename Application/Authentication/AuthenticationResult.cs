using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);

}
