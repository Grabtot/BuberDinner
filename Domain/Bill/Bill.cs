using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Bill(
            BillId id,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price)
        {
            return new Bill(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.Now,
                DateTime.Now);
        }

    }
}
