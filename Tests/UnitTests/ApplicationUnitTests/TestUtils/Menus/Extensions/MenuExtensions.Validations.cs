using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Domain.Menu;

namespace ApplicationUnitTests.TestUtils.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
        {
            Assert.Equal(command.Name, menu.Name);
            Assert.Equal(command.Description, menu.Description);
            Assert.Equal(command.Sections?.Count, menu.Sections.Count);
        }
    }
}
