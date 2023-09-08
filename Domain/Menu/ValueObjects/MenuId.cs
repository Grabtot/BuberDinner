﻿using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        private MenuId() { }

        public static MenuId Create(string id) => Create(Guid.Parse(id));

        public static MenuId Create(Guid id) => new(id);

        public static MenuId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
