namespace BuberDinner.Contracts.Authentication
{
    public record AuthenticationResponse
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Token { get; init; }
    }
}
