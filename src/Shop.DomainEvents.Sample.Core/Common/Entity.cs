using System.Collections.Generic;
using MediatR;

namespace Shop.DomainEvents.Sample.Core.Common
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem) 
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem) 
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}