using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;
using BuberDinner.Domain.User.ValueObjects;
using Rating = BuberDinner.Domain.Guest.Entities.Rating;

namespace BuberDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<Rating> _ratings = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public UserId UserId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public IReadOnlyCollection<DinnerId> PastDinnerIds
            => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds
            => _pendingDinnerIds.AsReadOnly();

        public IReadOnlyList<BillId> BillIds
            => _billIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds
            => _menuReviewIds.AsReadOnly();

        public IReadOnlyList<Rating> Ratings
            => _ratings.AsReadOnly();

        private Guest(GuestId id,
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

        private Guest() { }

        public static Guest Create(string firstName,
                     string lastName,
                     string profileImage,
                     UserId userId)
        {
            return new(
                GuestId.CreateUnique(),
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
