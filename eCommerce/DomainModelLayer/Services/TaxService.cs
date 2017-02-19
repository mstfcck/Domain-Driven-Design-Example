using eCommerce.DomainModelLayer.Customers;
using eCommerce.DomainModelLayer.Products;
using eCommerce.DomainModelLayer.Tax;
using eCommerce.DomainModelLayer.Tax.Enums;
using eCommerce.DomainModelLayer.Tax.Specs;
using eCommerce.Helpers.Domain;
using eCommerce.Helpers.Repository;
using System;

namespace eCommerce.DomainModelLayer.Services
{
    public class TaxService : IDomainService
    {
        private readonly IRepository<CountryTax> countryTax;
        private readonly Settings settings;

        public TaxService(Settings settings, IRepository<CountryTax> countryTax)
        {
            this.countryTax = countryTax;
            this.settings = settings;
        }

        public decimal Calculate(Customer customer, Product product)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (product == null)
                throw new ArgumentNullException("product");

            CountryTax customerCountryTax = this.countryTax.FindOne(new CountryTypeOfTaxSpec(customer.CountryId, TaxType.Customer));
            CountryTax businessCountryTax = this.countryTax.FindOne(new CountryTypeOfTaxSpec(settings.BusinessCountry.Id, TaxType.Business));

            return (product.Cost * customerCountryTax.Percentage)
                     + (product.Cost * businessCountryTax.Percentage);
        }
    }
}