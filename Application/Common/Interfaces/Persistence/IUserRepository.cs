﻿using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
        void Add(User user);
    }
}
