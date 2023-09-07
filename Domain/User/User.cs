using BuberDinner.Domain.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Entities
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private User(UserId id,
                    string firstName,
                    string lastName,
                    string email,
                    string password,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(string firstName,
                    string lastName,
                    string email,
                    string password)
        {
            return new(
                UserId.GenerateUnique(),
                firstName,
                lastName,
                email,
                password,
                DateTime.Now,
                DateTime.Now);
        }
    }
}
