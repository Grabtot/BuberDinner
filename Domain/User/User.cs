﻿using BuberDinner.Domain.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Entities
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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

        private User() { }

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
