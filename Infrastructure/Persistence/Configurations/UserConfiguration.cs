using BuberDinner.Domain.User;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
        }

        private static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Id)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));
        }
    }
}
