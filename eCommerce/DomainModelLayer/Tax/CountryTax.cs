using eCommerce.DomainModelLayer.Countries;
using eCommerce.DomainModelLayer.Tax.DomainEvents;
using eCommerce.DomainModelLayer.Tax.Enums;
using eCommerce.Helpers.Domain;
using System;

namespace eCommerce.DomainModelLayer.Tax
{
    public class CountryTax : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual Country Country { get; protected set; }
        public virtual decimal Percentage { get; protected set; }
        public virtual TaxType Type { get; protected set; }

        public static CountryTax Create(TaxType type, Country country, decimal percentage)
        {
            return Create(Guid.NewGuid(), type, country, percentage);
        }

        public static CountryTax Create(Guid id, TaxType type, Country country, decimal percentage)
        {
            CountryTax countryTax = new CountryTax()
            {
                Id = id,
                Country = country,
                Percentage = percentage,
                Type = type
            };

            DomainEventsHelper.Raise<CountryTaxCreatedDomainEvent>(new CountryTaxCreatedDomainEvent() { CountryTax = countryTax });

            return countryTax;
        }
    }
}