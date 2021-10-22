using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DomainEvents.Sample.Core.Orders.Events;

namespace Shop.DomainEvents.Sample.ApplicationService.DomainEventsHandlers.OrderStarted
{
    public class OrderStartedHandler : INotificationHandler<OrderStartedEvent>
    {
        public async Task Handle(OrderStartedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Order Started Handle: {notification.Order.Id}");

            await Task.FromResult(0);
        }
    }
}