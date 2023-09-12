using BuberDinner.Domain.Menu.Events;
using MediatR;

namespace BuberDinner.Application.Menus.Events
{
    public class CreatedHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}