﻿using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static HostId Create(string hostId)
        {
            return new(Guid.Parse(hostId));
        }
    }
}