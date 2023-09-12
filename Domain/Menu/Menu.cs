using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public HostId HostId { get; private set; }

        public IReadOnlyList<MenuSection> Sections
            => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds
            => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds
            => _menuReviewIds.AsReadOnly();

        private Menu(
            MenuId menuId,
            string name,
            string description,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            HostId hostId,
            AverageRating averageRating,
            List<MenuSection>? sections = null) : base(menuId)
        {
            Name = name;
            Description = description;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            HostId = hostId;
            AverageRating = averageRating;
            _sections = sections ?? new List<MenuSection>();
        }

        private Menu() { }
        public static Menu Create(
            string name,
            string description,
            HostId hostId,
            List<MenuSection>? sections = null)
        {
            Menu menu = new(
                MenuId.CreateUnique(),
                name,
                description,
                DateTime.Now,
                DateTime.Now,
                hostId,
                AverageRating.Create(),
                sections ?? new());

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
