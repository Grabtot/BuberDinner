using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Menu;
using Mapster;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;

namespace BuberDinner.Api.Common.Mapping
{
    public class MenuMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => GetRating(src.AverageRating))
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(id => id.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(id => id.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        }

        private double? GetRating(AverageRating rating)
        {
            return rating.RatingsCount > 0 ?
                rating.Value
                : null;
        }
    }
}
