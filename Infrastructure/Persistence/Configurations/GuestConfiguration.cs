using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            ConfigureGuestsTable(builder);
            ConfigureGuestPendingDinnerIdsTable(builder);
            ConfigureGuestPastDinnerIdsTable(builder);
            ConfigureGuestBillIdsTable(builder);
            ConfigureGuestMenuReviewIdsTable(builder);
            ConfigureGuestRatingsTable(builder);
        }

        private static void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.Ratings, ratingBuilder =>
            {
                ratingBuilder.ToTable("GuestRatings");

                ratingBuilder.WithOwner().HasForeignKey("GuestId");

                ratingBuilder.HasKey("Id", "GuestId");

                ratingBuilder.Property(rating => rating.Id)
                    .HasConversion(
                        id => id.Value,
                        value => RatingId.Create(value));

                ratingBuilder.Property(rating => rating.HostId)
                    .HasConversion(IdConvertors.HostIdConvertor);

                ratingBuilder.Property(rating => rating.DinnerId)
                    .HasConversion(IdConvertors.DinnerIdConvertor);
            });

            builder.Metadata.FindNavigation(nameof(Guest.Ratings))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureGuestMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.MenuReviewIds, reviewBuilder =>
            {
                reviewBuilder.ToTable("GuestMenuReviewIds");

                reviewBuilder.WithOwner().HasForeignKey("GuestId");

                reviewBuilder.HasKey("Value", "GuestId");

                reviewBuilder.Property(review => review.Value)
                    .HasColumnName("GuestMenuReviewId");
            });

            builder.Metadata.FindNavigation(nameof(Guest.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.BillIds, billBuilder =>
            {
                billBuilder.ToTable("GuestBillIds");

                billBuilder.WithOwner().HasForeignKey("GuestId");

                billBuilder.HasKey("Value", "GuestId");

                billBuilder.Property(bill => bill.Value)
                    .HasColumnName("GuestBillId");
            });

            builder.Metadata.FindNavigation(nameof(Guest.BillIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureGuestPendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.PastDinnerIds, dinnerBuilder =>
            {
                dinnerBuilder.ToTable("GuestPendingDinnerIds");

                dinnerBuilder.WithOwner().HasForeignKey("GuestId");

                dinnerBuilder.Property(dinner => dinner.Value)
                    .HasColumnName("GuestDinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Guest.PastDinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureGuestPastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.PendingDinnerIds, dinnerBuilder =>
            {
                dinnerBuilder.ToTable("GuestPastDinnerIds");

                dinnerBuilder.WithOwner().HasForeignKey("GuestId");

                dinnerBuilder.Property(dinner => dinner.Value)
                    .HasColumnName("GuestDinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Guest.PendingDinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(guest => guest.Id)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder.OwnsOne(guest => guest.AverageRating);

            builder.Property(guest => guest.UserId)
                .HasConversion(IdConvertors.UserIdConvertor);
        }
    }
}
