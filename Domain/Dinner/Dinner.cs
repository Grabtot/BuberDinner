using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;
using ErrorOr;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations;

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; private set; } = null;
        public DateTime? EndedDateTime { get; private set; } = null;
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; private set; }
        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }
        public IReadOnlyList<Reservation> Reservations
            => _reservations.AsReadOnly();

        private Dinner(DinnerId id,
                       string name,
                       string description,
                       DateTime startDateTime,
                       DateTime endDateTime,
                       DateTime createdDateTime,
                       DateTime updatedDateTime,
                       DinnerStatus status,
                       bool isPublic,
                       int maxGuests,
                       Price price,
                       HostId hostId,
                       MenuId menuId,
                       string imageUrl,
                       Location location) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
        }

        public static Dinner Create(string name,
                                    string description,
                                    DateTime startDateTime,
                                    DateTime endDateTime,
                                    bool isPublic,
                                    int maxGuests,
                                    Price price,
                                    HostId hostId,
                                    MenuId menuId,
                                    string imageUrl,
                                    Location location)
        {
            return new Dinner(DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                DateTime.Now,
                DateTime.Now,
                DinnerStatus.Upcoming,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location);
        }

        public ErrorOr<ReservationId> AddReservation(Reservation reservation)
        {
            if (_reservations.Sum(r => r.GuestCount) + reservation.GuestCount > MaxGuests)
            {
                return Errors.Dinner.MaxGuestsCount;
            }
            _reservations.Add(reservation);
            return reservation.Id;
        }

        public void StartDinner()
        {
            StartedDateTime = DateTime.Now;
            Status = DinnerStatus.InProgress;
        }



        public enum DinnerStatus
        {
            Upcoming,
            InProgress,
            Ended,
            Cancelled
        }
    }
}
