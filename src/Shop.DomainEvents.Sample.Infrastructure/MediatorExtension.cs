
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shop.DomainEvents.Sample.Core.Common;

namespace Shop.DomainEvents.Sample.Infrastructure
{
    public static class MediatorExtension 
    {
        public static async Task DispatchEvents<T>(this IMediator mediator, T entity) where T : Entity
        {
            var domainEvents = entity.DomainEvents; 
                
            // var tasks = domainEvents.Select(async (domainEvent) => {
            //     await mediator.Publish(domainEvent);
            // });

            entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)  
                await mediator.Publish(domainEvent);

            await Task.WhenAll();
        }
    }
}