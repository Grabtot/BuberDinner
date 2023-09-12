﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.User;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }
    }
}
