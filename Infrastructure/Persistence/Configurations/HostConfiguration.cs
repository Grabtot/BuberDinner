using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            ConfigureHostsTable(builder);
            ConfigureHostMenuIdsTable(builder);
            ConfigureHostDinnerIdsTable(builder);
        }

        private static void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(h => h.DinnerIds, dib =>
            {
                dib.WithOwner().HasForeignKey("HostId");

                dib.ToTable("HostDinnerIds");

                dib.Property(d => d.Value)
                    .HasColumnName("HostDinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(h => h.MenuIds, mib =>
            {
                mib.WithOwner().HasForeignKey("HostId");

                mib.ToTable("HostMenuIds");

                mib.Property(m => m.Value)
                    .HasColumnName("HostMenuId");
            });

            builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
        {
            builder.Property(h => h.Id)
                .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

            builder.OwnsOne(h => h.AverageRating);

            builder.Property(h => h.UserId)
                .HasConversion(IdConvertors.UserIdConvertor);
        }
    }
}
