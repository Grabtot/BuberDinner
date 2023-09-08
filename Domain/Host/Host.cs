using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public UserId UserId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public IReadOnlyList<MenuId> MenuIds
            => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds
            => _dinnerIds.AsReadOnly();

        private Host(HostId id,
                    string firstName,
                    string lastName,
                    string profileImage,
                    AverageRating averageRating,
                    UserId userId,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private Host() { }

        public static Host Create(string firstName,
                    string lastName,
                    string profileImage,
                     UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                AverageRating.Create(),
                userId,
                DateTime.Now,
                DateTime.Now);
        }
    }
}
