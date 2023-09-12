using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Events
{
    public record MenuCreated(Menu Menu) : IDomainEvent
    {
    }
}
