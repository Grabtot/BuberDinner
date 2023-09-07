using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class Rating : Entity<RatingId>
    {
        public double Value { get; }
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Rating(RatingId id,
                       double value,
                       HostId hostId,
                       DinnerId dinnerId,
                       DateTime createdDateTime,
                       DateTime updatedDateTime) : base(id)
        {
            Value = value;
            HostId = hostId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Rating Create(double value,
                                    HostId hostId,
                                    DinnerId dinnerId)
        {
            return new(
                        RatingId.CreateUnique(),
                        value,
                        hostId,
                        dinnerId,
                        DateTime.Now,
                        DateTime.Now);
        }
    }
}