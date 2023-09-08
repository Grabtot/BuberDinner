﻿using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.User.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        private UserId(Guid value)
        {
            Value = value;
        }

        private UserId() { }

        public static UserId Create(Guid id) => new(id);

        public static UserId GenerateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}