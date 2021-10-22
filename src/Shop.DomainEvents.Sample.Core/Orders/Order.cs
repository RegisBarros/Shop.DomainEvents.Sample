using System;
using System.Collections.Generic;
using System.Linq;
using Shop.DomainEvents.Sample.Core.Common;
using Shop.DomainEvents.Sample.Core.Orders.Events;

namespace Shop.DomainEvents.Sample.Core.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Order(String userId)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;

            var orderStarted = new OrderStartedEvent(userId, this);
            this.AddDomainEvent(orderStarted);
        }

        public Guid Id { get; private set; }    

        public decimal Amount { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public ICollection<Item> Items { get; private set; } = new List<Item>();

        public void AddItem(String code, string description, int quantity, decimal price) {

            Items.Add(new Item(code, description, quantity, price));

            CalculateAmount();
        }

        public void CalculateAmount() {

            Amount = Items.Sum(i => i.Amount);
        }
    }
}