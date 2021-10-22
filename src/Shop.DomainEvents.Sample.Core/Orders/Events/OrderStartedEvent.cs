using MediatR;

namespace Shop.DomainEvents.Sample.Core.Orders.Events
{
    public class OrderStartedEvent : INotification
    {
        public OrderStartedEvent(string userId, Order order)
        {
            UserId = userId;
            Order = order;
        }

        public string UserId { get; }
        public Order Order { get; }
    }
}