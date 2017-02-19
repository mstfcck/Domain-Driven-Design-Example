using eCommerce.Helpers.Domain;
using System.Collections.Generic;

namespace eCommerce.Helpers.Repository
{
    public interface IDomainEventRepository
    {
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;

        IEnumerable<DomainEventRecord> FindAll();
    }
}