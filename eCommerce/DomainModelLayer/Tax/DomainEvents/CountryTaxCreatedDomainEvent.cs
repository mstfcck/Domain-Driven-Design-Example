using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Tax.DomainEvents
{
    public class CountryTaxCreatedDomainEvent : DomainEvent
    {
        public CountryTax CountryTax { get; set; }

        public override void Flatten()
        {
            this.Args.Add("CountryTaxId", CountryTax.Id);
            this.Args.Add("CountryTaxCountryId", CountryTax.Country.Id);
            this.Args.Add("CountryTaxPercentage", this.CountryTax.Percentage);
            this.Args.Add("CountryTaxType", this.CountryTax.Type);
        }
    }
}