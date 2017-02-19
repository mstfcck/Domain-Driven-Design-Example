using eCommerce.DomainModelLayer.Countries.DomainEvents;
using eCommerce.Helpers.Domain;
using System;

namespace eCommerce.DomainModelLayer.Countries
{
    public class Country : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static Country Create(Guid id, string name)
        {
            Country country = new Country()
            {
                Id = id,
                Name = name
            };

            DomainEventsHelper.Raise<CountryCreatedDomainEvent>(new CountryCreatedDomainEvent() { Country = country });

            return country;
        }
    }
}