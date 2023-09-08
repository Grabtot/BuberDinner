using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuReview
{
    public sealed class MenuReview
        : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; private set; }
        public string Comment { get; private set; }
        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public GuestId GuestId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public MenuReview(MenuReviewId id,
                          Rating rating,
                          string comment,
                          HostId hostId,
                          MenuId menuId,
                          GuestId guestId,
                          DinnerId dinnerId,
                          DateTime createdDateTime,
                          DateTime updatedDateTime) : base(id)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private MenuReview() { }

        public static MenuReview Create(Rating rating,
                                        string comment,
                                        HostId hostId,
                                        MenuId menuId,
                                        GuestId guestId,
                                        DinnerId dinnerId)
        {
            return new(
                MenuReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.Now,
                DateTime.Now);
        }
    }
}
