using ApplicationUnitTests.TestUtils.Menus.Extensions;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using Moq;

namespace ApplicationUnitTests.Menus.Commands
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly Mock<IMenuRepository> _repositoryMock;
        private readonly CreateMenuCommandHandler _handler;

        public CreateMenuCommandHandlerTests()
        {
            _repositoryMock = new Mock<IMenuRepository>();
            _handler = new(_repositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommand))]
        public async Task Success(CreateMenuCommand command)
        {

            //Act
            ErrorOr.ErrorOr<BuberDinner.Domain.Menu.Menu> result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsError);
            result.Value.ValidateCreatedFrom(command);
            _repositoryMock.Verify(m => m.Add(result.Value), Times.Once());
        }

        public static List<object[]> ValidCreateMenuCommand()
        {
            throw new NotImplementedException();
        }
    }
}
