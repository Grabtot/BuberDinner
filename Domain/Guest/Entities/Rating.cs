using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class Rating : Entity<RatingId>
    {
        public double Value { get; private set; }
        public HostId HostId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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

        private Rating() { }

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