using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BuberDinner.Infrastructure.Persistence.Configurations.Common.IdConvertors;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIds(builder);
            ConfigureMenuReviewIds(builder);

        }

        private static void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(menu => menu.MenuReviewIds, idBuilder =>
            {
                idBuilder.ToTable("MenuReviewIds");

                idBuilder.WithOwner().HasForeignKey("MenuId");

                idBuilder.HasKey("Id");

                idBuilder.Property(id => id.Value)
                    .HasColumnName("ReviewId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
             .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(menu => menu.DinnerIds, idBuilder =>
            {
                idBuilder.ToTable("MenuDinnerIds");

                idBuilder.WithOwner().HasForeignKey("MenuId");

                idBuilder.HasKey("Id");

                idBuilder.Property(id => id.Value)
                    .HasColumnName("DinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
             .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(menu => menu.Sections, sectionBuilder =>
            {
                sectionBuilder.ToTable("MenuSections");

                sectionBuilder.WithOwner().HasForeignKey("MenuId");

                sectionBuilder.HasKey("Id", "MenuId");

                sectionBuilder.Property(section => section.Id)
                    .HasColumnName("MenuSectionId")
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value));

                sectionBuilder.Property(section => section.Name)
                    .HasMaxLength(100);

                sectionBuilder.Property(section => section.Description)
                    .HasMaxLength(100);

                sectionBuilder.OwnsMany(section => section.Items, itemBuilder =>
                {
                    itemBuilder.ToTable("MenuItems");

                    itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                    itemBuilder.Property(item => item.Id)
                        .HasColumnName("MenuItemId")
                        .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value));

                    itemBuilder.Property(item => item.Name)
                        .HasMaxLength(100);

                    itemBuilder.Property(item => item.Description)
                        .HasMaxLength(100);
                });

                sectionBuilder.Navigation(section => section.Items).Metadata.SetField("_items");
                sectionBuilder.Navigation(section => section.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(menu => menu.Id);

            builder.Property(menu => menu.Id)
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.Property(menu => menu.Name)
                .HasMaxLength(100);

            builder.Property(menu => menu.Description)
                .HasMaxLength(100);

            builder.OwnsOne(menu => menu.AverageRating);

            builder.Property(menu => menu.HostId)
                   .HasConversion(HostIdConvertor);
        }
    }
}
