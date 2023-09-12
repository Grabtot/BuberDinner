using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class DinnerConfiguration : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigureDinnersTable(builder);
            ConfigureReservationsTable(builder);
        }

        private static void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(reservation => reservation.Reservations, reservationBuilder =>
            {
                reservationBuilder.ToTable("DinnerReservations");

                reservationBuilder.WithOwner().HasForeignKey("DinnerId");

                reservationBuilder.HasKey("Id", "DinnerId");

                reservationBuilder.Property(reservation => reservation.Id)
                    .HasConversion(
                        id => id.Value,
                        value => ReservationId.Create(value));

                reservationBuilder.Property(reservation => reservation.GuestId)
                    .HasConversion(IdConvertors.GuestIdConvertor);

                reservationBuilder.Property(reservation => reservation.BillId)
                    .HasConversion(IdConvertors.BillIdConvertor);
            });
            builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.Property(dinner => dinner.Name)
                .HasMaxLength(100);

            builder.Property(dinner => dinner.Id)
                .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

            builder.Property(dinner => dinner.Description)
                .HasMaxLength(150);

            builder.OwnsOne(dinner => dinner.Price);

            builder.Property(dinner => dinner.HostId)
                .HasConversion(IdConvertors.HostIdConvertor);

            builder.Property(dinner => dinner.MenuId)
                .HasConversion(IdConvertors.MenuIdConvertor);

            builder.OwnsOne(dinner => dinner.Location);
        }
    }
}
