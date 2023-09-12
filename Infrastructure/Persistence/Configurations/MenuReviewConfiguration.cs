using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuReviewConfiguration : IEntityTypeConfiguration<MenuReview>
    {
        public void Configure(EntityTypeBuilder<MenuReview> builder)
        {
            ConfigureMenuReviewsTable(builder);
        }

        private static void ConfigureMenuReviewsTable(EntityTypeBuilder<MenuReview> builder)
        {
            builder.Property(review => review.Id)
                .HasConversion(
                    id => id.Value,
                    value => MenuReviewId.Create(value));

            builder.OwnsOne(review => review.Rating);

            builder.Property(review => review.HostId)
                .HasConversion(IdConvertors.HostIdConvertor);

            builder.Property(review => review.MenuId)
                .HasConversion(IdConvertors.MenuIdConvertor);

            builder.Property(review => review.GuestId)
                .HasConversion(IdConvertors.GuestIdConvertor);

            builder.Property(review => review.DinnerId)
                .HasConversion(IdConvertors.DinnerIdConvertor);
        }
    }
}
