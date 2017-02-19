using eCommerce.DomainModelLayer.Products.DomainEvents;
using eCommerce.Helpers.Domain;
using System;

namespace eCommerce.DomainModelLayer.Products
{
    public class ProductCode : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public static ProductCode Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static ProductCode Create(Guid id, string name)
        {
            ProductCode productCode = new ProductCode()
            {
                Id = id,
                Name = name
            };

            DomainEventsHelper.Raise<ProductCodeCreatedDomainEvent>(new ProductCodeCreatedDomainEvent() { ProductCode = productCode });

            return productCode;
        }
    }
}