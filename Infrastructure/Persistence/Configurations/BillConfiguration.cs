using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            ConfigureBillsTable(builder);
        }

        private static void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(bill => bill.Id)
                .HasConversion(
                    id => id.Value,
                    value => BillId.Create(value));

            builder.Property(bill => bill.DinnerId)
                .HasConversion(IdConvertors.DinnerIdConvertor);

            builder.Property(bill => bill.GuestId)
                .HasConversion(IdConvertors.GuestIdConvertor);

            builder.Property(bill => bill.HostId)
                .HasConversion(IdConvertors.HostIdConvertor);

            builder.OwnsOne(bill => bill.Price);
        }
    }
}
