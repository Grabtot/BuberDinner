using BuberDinner.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? context)
        {
            if (context is null)
            {
                return;
            }

            List<IHasDomainEvents> entitiesWithDomainEvents = context.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();

            List<IDomainEvent> events = entitiesWithDomainEvents.SelectMany(e => e.DomainEvents).ToList();

            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            foreach (IDomainEvent? domainEvent in events)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
