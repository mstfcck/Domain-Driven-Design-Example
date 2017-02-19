using eCommerce.DomainModelLayer.Tax.Enums;
using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Tax.Specs
{
    public class CountryTypeOfTaxSpec : SpecificationBase<CountryTax>
    {
        private readonly Guid countryId;
        private readonly TaxType taxType;

        public CountryTypeOfTaxSpec(Guid countryId, TaxType taxType)
        {
            this.countryId = countryId;
            this.taxType = taxType;
        }

        public override Expression<Func<CountryTax, bool>> SpecExpression
        {
            get
            {
                return countryTax => countryTax.Country.Id == this.countryId
                    && countryTax.Type == this.taxType;
            }
        }

        public override bool Equals(object obj)
        {
            CountryTypeOfTaxSpec countryTypeOfTaxSpecCompare = obj as CountryTypeOfTaxSpec;
            if (countryTypeOfTaxSpecCompare == null)
                throw new InvalidCastException("obj");

            return countryTypeOfTaxSpecCompare.countryId == this.countryId &&
                countryTypeOfTaxSpecCompare.taxType == this.taxType;
        }
    }
}