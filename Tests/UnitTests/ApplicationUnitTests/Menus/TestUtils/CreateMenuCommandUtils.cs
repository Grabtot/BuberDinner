using ApplicationUnitTests.TestUtils;
using BuberDinner.Application.Menus.Commands.CreateMenu;

namespace ApplicationUnitTests.Menus.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand()
        {
            return new(
                Constants.Menu.Name,
                Constants.Menu.Description,
                Constants.Host.HostId.Value.ToString(),
                CreateSections());
        }

        public static List<MenuSectionCommand> CreateSections(int count = 3)
        {
            return Enumerable.Range(0, count)
                 .Select(index => new MenuSectionCommand(
                     Constants.Menu.SectionNameFromIndex(index),
                     Constants.Menu.SectionDescriptionFromIndex(index),
                     CreateItems()))
                 .ToList();
        }

        public static List<MenuItemCommand> CreateItems(int count = 3)
        {
            return Enumerable.Range(0, count)
                .Select(index => new MenuItemCommand(
                    Constants.Menu.ItemNameFromIndex(index),
                    Constants.Menu.ItemDescriptionFromIndex(index)))
                .ToList();

        }
    }
}
