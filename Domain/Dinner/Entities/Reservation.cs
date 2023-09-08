using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; private set; }
        public ReservationStatus Status { get; private set; }
        public GuestId GuestId { get; private set; }
        public BillId BillId { get; private set; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Reservation(ReservationId id,
                           int guestCount,
                           ReservationStatus status,
                           GuestId guestId,
                           BillId billId,
                           DateTime? arrivalDateTime,
                           DateTime createdDateTime,
                           DateTime updatedDateTime) : base(id)
        {
            GuestCount = guestCount;
            Status = status;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private Reservation() { }

        public static Reservation Create(int guestCount,
                                  GuestId guestId,
                                  BillId billId,
                                  DateTime? arrivalDateTime)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                ReservationStatus.PendingGuestConfirmation,
                guestId,
                billId,
                arrivalDateTime,
                DateTime.Now,
                DateTime.Now);
        }

        public enum ReservationStatus
        {
            PendingGuestConfirmation,
            Reserved,
            Cancelled
        }
    }
}