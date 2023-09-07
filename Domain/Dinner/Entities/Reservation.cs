using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus Status { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

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